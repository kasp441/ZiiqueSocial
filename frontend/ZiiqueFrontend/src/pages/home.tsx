import { NewPost } from "@/components/comp/newPost";
import { Posts, Profile } from "../Entities/BackendEnt";
import { useCallback, useEffect, useRef, useState } from "react";
import { postService } from "@/components/services/postService";
import { Post } from "@/components/comp/post";
import { Dictionary } from "@/Entities/HelperEnt";
import { profileService } from "@/components/services/profileService";

export function Home() {
  const [posts, setPosts] = useState<Posts>({
    items: [],
    pageNumber: 0,
    pageSize: 0,
    totalPages: 0,
    totalRecords: 0,
  });
  const [profiles, setProfiles] = useState<Dictionary<Profile>>({});  
  const [loading, setLoading] = useState<boolean>(false);
  const [pageNumber, setPageNumber] = useState<number>(1);
  const [hasMore, setHasMore] = useState<boolean>(true);

  const observer = useRef<IntersectionObserver | null>(null);
  const isInitialLoad = useRef<boolean>(true);

  const loadMorePosts = useCallback(async () => {
    if (loading || !hasMore) return;
    setLoading(true);

    const newPosts = await postService.getPosts({
      page: pageNumber,
      pageSize: 10,
    });
    const newProfiles: Dictionary<Profile> = {};
    for (const post of newPosts.items) {
      if (!profiles[post.profileId]) {
        newProfiles[post.profileId] = await profileService.getProfile(post.profileId);
      }
    }
    setProfiles((prevProfiles) => ({ ...prevProfiles, ...newProfiles }));
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
  }, [loading, hasMore, pageNumber, posts.items.length, profiles]);

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
    <div className="grid grid-cols-1">
      <div className="justify-items-center">
        <NewPost />
        <br />
        {posts.items.map((post, index) => (
          <div
            className="w-1/2 pb-5"
            key={post.id}
            ref={index === posts.items.length - 1 ? lastPostElementRef : null}
          >
            <Post
              title={post.title}
              content={post.content}
              date={post.createdAt}
              userIcon={profiles[post.profileId]?.profileIcon}
              userName={profiles[post.profileId]?.displayName}
              profileId={post.profileId}
            />
          </div>
        ))}
      </div>
      {loading && (
        <div className="flex justify-center items-center">
          <div
            className="spinner-border animate-spin inline-block w-8 h-8 border-4 rounded-full"
            role="status"
          >
            <span className="visually-hidden">Loading...</span>
          </div>
        </div>
      )}
      {!hasMore && !loading && (
        <div className="flex justify-center items-center">
          <h1>YOU HAVE SEEN EVERYTHING</h1>
        </div>
      )}
    </div>
  );
}
