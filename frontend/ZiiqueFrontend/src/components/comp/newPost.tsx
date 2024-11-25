import { Button } from "../ui/button";
import { Card, CardContent, CardFooter, CardHeader, CardTitle } from "../ui/card";

export function NewPost() {
  return (
    <Card className="w-1/2 min-h-96 border-Accent border-4 flex flex-col">
        <CardHeader className="border-b-2 border-Accent">
            <CardTitle className="flex justify-between text-text">
                New Post
            </CardTitle>
        </CardHeader>
        <CardContent className="flex-1">
            <form>
                <div>
                    <label htmlFor="title">Title</label>
                    <input type="text" placeholder="Title" className="w-full" />
                </div>
               <div>
                    <label htmlFor="Content">Content</label>
                    <textarea placeholder="Content" className="w-full" />
               </div>
                
            </form>
        </CardContent>
        <CardFooter className="flex justify-between">
            <Button className="bg-Primary">Post</Button>
        </CardFooter>
    </Card>
  );
}