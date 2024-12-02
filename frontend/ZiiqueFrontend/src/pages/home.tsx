import { NewPost } from "@/components/comp/newPost";
import { Posts } from "../Entities/BackendEnt";
import { useEffect, useState } from "react";
import { postService } from "@/components/services/postService";
import { Post } from "@/components/comp/post";

export function Home() {
  const [posts, setPosts] = useState<Posts>({ items: [], pageNumber: 0, pageSize: 0, totalPages: 0, totalRecords: 0 });
  const [loading, setLoading] = useState<boolean>(true);

  useEffect(() => {
    setLoading(true);
    postService.getPosts({ page: 1, pageSize: 10 }).then((data: Posts) => {
      setPosts(data);
      setLoading(false);
    });
  }, []);

  return (
    <div className="grid grid-cols-1">
      <div className="justify-items-center">
        <NewPost />
        <br/>
        {posts.items.map((post) => (
          <Post
            key={post.id}
            title={post.title}
            content={post.content}
            date={post.createdAt}
            userIcon="Brian"
            userName="SmiteAndSlam"
          />
        ))}
      </div>
    {loading && (
      <div className="flex justify-center items-center">
        <div className="spinner-border animate-spin inline-block w-8 h-8 border-4 rounded-full" role="status">
          <span className="visually-hidden">Loading...</span>
        </div>
      </div>
    )}
    </div>
  );
}
