import { PostCreate } from "@/Entities/BackendEnt";
import { postService } from "../services/postService";
import { Button } from "../ui/button";
import { Card, CardContent, CardFooter, CardHeader, CardTitle } from "../ui/card";
import { Switch } from "../ui/switch";
import { useState } from "react";

export function NewPost() {
    const [title, setTitle] = useState<string>('');
    const [content, setContent] = useState<string>('');
    //const [onlyFolowers, setOnlyFolowers] = useState<boolean>(false);

    const post = async () => {
        const postToPost = {
            title,
            content,
            createdAt: new Date()
        } as PostCreate;
        postService.postPost(postToPost);
    };

  return (
    <Card className="w-1/2 min-h-96 border-Accent border-4 flex flex-col">
        <CardHeader className="border-b-2 border-Accent">
            <CardTitle className="flex justify-between text-text">
                What's on your mind?
            </CardTitle>
        </CardHeader>
        <CardContent className="flex-1">
            <form>
                <div className="flex flex-col items-start">
                    <label className="font-bold" htmlFor="title">Title</label>
                    <input onChange={e => setTitle(e.target.value)} type="text" placeholder="I saw on the bustop" className="w-full" />
                </div>
                <div className="flex flex-col items-start">
                    <label className="font-bold" htmlFor="Content">Content</label>
                    <textarea onChange={e => setContent(e.target.value)} placeholder="One old lady, that could lift..." className="w-full min-h-32" />
                </div>
                <div className="flex flex-col items-start">
                    <label className="font-bold" htmlFor="onlyFolowers">Only Folowers</label>
                    <Switch id="onlyFolowers"/>
                </div>
            </form>
        </CardContent>
        <CardFooter className="flex justify-between">
            <Button onClick={() => post()} className="bg-Primary">Post</Button>
        </CardFooter>
    </Card>
  );
}