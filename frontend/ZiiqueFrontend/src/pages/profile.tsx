import { profileService } from "@/components/services/profileService";
import { useCallback, useEffect, useRef, useState } from "react";
import type { Posts, Profile } from "@/Entities/BackendEnt";
import { useParams } from "react-router-dom";
import { postService } from "@/components/services/postService";
import { Post } from "@/components/comp/post";
import { useKeycloak } from "@react-keycloak/web";
import { followService } from "@/components/services/followService";
import { useGlobalStateFollowers } from "@/components/helpers/globalStateContext";
import { Button } from "@/components/ui/button";

export function Profile() {
  const { id } = useParams();
  const { keycloak } = useKeycloak();
  const { followers, setFollowers } = useGlobalStateFollowers();

  const [profile, setProfile] = useState<Profile>();
  const [posts, setPosts] = useState<Posts>({
    items: [],
    pageNumber: 0,
    pageSize: 0,
    totalPages: 0,
    totalRecords: 0,
  });
  const [loading, setLoading] = useState<boolean>(false);
  const [pageNumber, setPageNumber] = useState<number>(1);
  const [hasMore, setHasMore] = useState<boolean>(true);

  const observer = useRef<IntersectionObserver | null>(null);
  const isInitialLoad = useRef<boolean>(true);

  const loadMorePosts = useCallback(async () => {
    if (loading || !hasMore) return;
    setLoading(true);

    const newPosts = await postService.getPostsFromUser({
      id: id!,
      paginationFilter: { page: pageNumber, pageSize: 10 },
    });
    setPosts((prevPosts) => ({
      items: [...prevPosts.items, ...newPosts.items],
      pageNumber: newPosts.pageNumber,
      pageSize: newPosts.pageSize,
      totalPages: newPosts.totalPages,
      totalRecords: newPosts.totalRecords,
    }));
    setHasMore(
      newPosts.totalRecords > posts.items.length + newPosts.items.length
    );
    setLoading(false);
  }, [loading, hasMore, id, pageNumber, posts.items.length]);

  const lastPostElementRef = useCallback(
    (node: HTMLDivElement | null) => {
      if (loading) return;

      if (observer.current) observer.current.disconnect();

      observer.current = new IntersectionObserver((entries) => {
        if (entries[0].isIntersecting && hasMore) {
          setPageNumber((prev) => prev + 1);
        }
      });

      if (node) observer.current.observe(node);
    },
    [loading, hasMore]
  );

  useEffect(() => {
    if (id) {
      profileService.getProfile(id).then((profile) => {
        setProfile(profile);
      });
      if (keycloak.authenticated) {
        followService.getFollowers().then((followers) => {
          setFollowers(followers);
        });
      }
    }
  }, [id, keycloak.authenticated, keycloak.subject, setFollowers]);

  useEffect(() => {
    if (isInitialLoad.current) {
      isInitialLoad.current = false;
      loadMorePosts();
    }
  }, [loadMorePosts]);

  useEffect(() => {
    if (!isInitialLoad.current && pageNumber > 1) {
      loadMorePosts();
    }
  }, [pageNumber, loadMorePosts]);

  return (
    <div>
      {profile ? (
        <>
          <div className="flex flex-row place-items-start">
            <div className="mr-5">
              <img
                src={`https://api.dicebear.com/9.x/fun-emoji/svg?seed=${profile.profileIcon}`}
                alt="avatar"
                className="w-16 rounded-full"
              />
            </div>
            <div className="basis-3/4 text-left">
              <h2 className="text-4xl">{profile.displayName}</h2>
              <h3 className="font-bold">@{profile.username}</h3>
            </div>
            {keycloak.authenticated && keycloak.subject !== id ? (
              <div>
                {followers.includes(profile.Guid) ? (
                  <>
                    <Button
                      onClick={() => followService.unfollowUser(profile.Guid)}
                    >
                      Unfollow
                    </Button>
                  </>
                ) : (
                  <>
                    <Button
                      onClick={() => followService.followUser(profile.Guid)}
                    >
                      Follow
                    </Button>
                  </>
                )}
              </div>
            ) : (
              <></>
            )}
          </div>

          <br />
          <div className="justify-items-center">
            {posts.items.map((post, index) => (
              <div
                className="w-1/2 pb-5"
                key={post.id}
                ref={
                  index === posts.items.length - 1 ? lastPostElementRef : null
                }
              >
                <Post
                  title={post.title}
                  content={post.content}
                  date={post.createdAt}
                  userIcon={profile.profileIcon}
                  userName={profile.displayName}
                  profileId={post.profileId}
                />
              </div>
            ))}
          </div>
        </>
      ) : (
        <p>Loading...</p>
      )}
    </div>
  );
}
