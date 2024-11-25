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
          user="Tim"
        />
        <br />
        <Post
          title="My second post very looooooooooong post to see if it react correct"
          content="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus sem nunc, rutrum eu nisi id, aliquet mollis lacus. Suspendisse convallis condimentum dignissim. Vestibulum semper nulla vel pretium vehicula. Praesent quis maximus tortor. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Integer nec nunc pellentesque, feugiat diam vitae, varius felis. Morbi ut viverra lorem. Duis scelerisque pharetra augue sit amet iaculis. Vivamus et consectetur dolor. Donec vel ultrices tortor, hendrerit gravida lorem. Phasellus lorem tortor, vehicula eu tincidunt vitae, viverra volutpat massa. Etiam est magna, porttitor sed tellus vitae, efficitur rhoncus augue. Proin sed semper tortor."
          date={new Date()}
          user="Tim"
        />
      </div>
    </div>
  );
}
