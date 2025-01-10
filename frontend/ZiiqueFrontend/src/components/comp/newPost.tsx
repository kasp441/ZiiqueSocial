import { PostCreate } from "@/Entities/BackendEnt";
import { postService } from "../services/postService";
import { Button } from "../ui/button";
import { Card, CardContent, CardFooter, CardHeader, CardTitle } from "../ui/card";
import { useState } from "react";
import { DropdownMenu, DropdownMenuContent, DropdownMenuItem, DropdownMenuSeparator, DropdownMenuTrigger } from "../ui/dropdown-menu";
import { DropdownMenuLabel } from "@radix-ui/react-dropdown-menu";

export function NewPost() {
    const [title, setTitle] = useState<string>('');
    const [content, setContent] = useState<string>(''); 
    const [visibility, setVisibility] = useState<number>(0);    
    let visibilityText: string = '';

    const post = async () => {
        const postToPost = {
            title,
            content,
            createdAt: new Date(),
            visibility,
        } as PostCreate;
        postService.postPost(postToPost);
    };

    const setVisibilityText = (visibility: number) => {
        switch (visibility) {
            case 0:
                visibilityText = 'Public';
                break;  
            case 1:
                visibilityText = 'Folowers';
                break;
            case 2:
                visibilityText = 'Private';
                break;
            default:
                visibilityText = 'Public';
                break;
    }
    return visibilityText;};

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
                    <label className="font-bold" htmlFor="onlyFolowers">Post Visibility</label>
                    <div className="border-2 border-Accent rounded-md p-2">    
                        <DropdownMenu>
                            <DropdownMenuTrigger className="text-black font-bold">{setVisibilityText(visibility)}</DropdownMenuTrigger>
                            <DropdownMenuContent>
                                <DropdownMenuLabel>Post Visibility</DropdownMenuLabel>
                                <DropdownMenuSeparator></DropdownMenuSeparator>
                                <DropdownMenuItem onSelect={() => setVisibility(0)}>Public</DropdownMenuItem>
                                <DropdownMenuItem onSelect={() => setVisibility(1)}>Folowers</DropdownMenuItem>
                                <DropdownMenuItem onSelect={() => setVisibility(2)}>Private</DropdownMenuItem>     
                            </DropdownMenuContent>
                        </DropdownMenu>
                    </div>
                </div>
            </form>
        </CardContent>
        <CardFooter className="flex justify-between">
            <Button onClick={() => post()} className="bg-Primary">Post</Button>
        </CardFooter>
    </Card>
  );
}