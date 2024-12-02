import { NewPost } from "@/components/comp/newPost";
import { Post } from "@/components/comp/post";

export function Home() {
  return (
    <div className="grid grid-cols-1">
      <div className="justify-items-center">
        <NewPost />
        <br/>
        <Post
          title="My first post"
          content="This is my first post"
          date={new Date()}
          userIcon="Brian"
          userName="SmiteAndSlam"
        />
        <br />
        <Post
          title="My second post very looooooooooong post to see if it react correct"
          content="I love donuts https://www.youtube.com/watch?v=Vd4jKRzpF1Q"
          date={new Date()}
          userIcon="Robert"
          userName="FrogOnlyInJg"
        />
      </div>
    </div>
  );
}
