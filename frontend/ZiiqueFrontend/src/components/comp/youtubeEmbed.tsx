
export function YoutubeEmbed({ embedId }: { embedId: string }) {
    return (
        <div className="relative" style={{ paddingBottom: '56.25%' /* 16:9 aspect ratio */ }}>
            <iframe
                className="absolute top-0 left-0 w-full h-full"
                src={`https://www.youtube.com/embed/${embedId}`}
                title="YouTube video player"
                frameBorder="0"
                allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"
                allowFullScreen
            />
        </div>
    );
}