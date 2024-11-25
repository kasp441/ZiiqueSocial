import { Button } from "../ui/button";
import { Card, CardContent, CardFooter, CardHeader, CardTitle } from "../ui/card";

type PostProps = {
    title: string;
    content: string;
    date: Date;
    userIcon: string;
    userName: string;
};

export function Post({title, content, date, userIcon, userName}: PostProps) {
  return (
    <Card className="w-1/2 min-h-96 border-Accent border-4 flex flex-col">
        <CardHeader className="bg-Accent">
            <CardTitle className="flex justify-between text-background">
                <div className="self-center text-left line-clamp-1 max-w-96">
                    {title}
                </div>
                <div className="flex items-center">
                    <p className="mr-2">{userName}</p>
                    <img src={`https://api.dicebear.com/9.x/fun-emoji/svg?seed=${userIcon}`} alt="avatar" className="w-16 rounded-full"/>
                </div>
            </CardTitle>
        </CardHeader>
        <CardContent className="flex-1">
            <p className="text-start pt-5 text-wrap">{content}</p>
        </CardContent>
        <CardFooter className="flex justify-between">
            <Button className="bg-Primary">Like</Button>
            <p>{date.toDateString()}</p>
        </CardFooter>
    </Card>
  );
};