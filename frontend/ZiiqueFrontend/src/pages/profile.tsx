import { profileService } from "@/components/services/profileService";
import { useEffect, useState } from "react";
import type { Profile } from "@/Entities/BackendEnt";
import { useParams } from "react-router-dom";


export function Profile() {
    const { id } = useParams();

    const [profile, setProfile] = useState<Profile>();

    useEffect(() => {
        if (id) {
            console.log(id);
            profileService.getProfile(id).then((profile) => {
                setProfile(profile);
            });
        }
    }, [id]);

    return(
        <div>
            <h1>Profile</h1>
            {profile ? (
                <>
                    <h2>{profile.username}</h2> 
                    <h3>{profile.displayName}</h3>
                    <p>{profile.bio}</p>
                    <img
                        src={`https://api.dicebear.com/9.x/fun-emoji/svg?seed=${profile.profileIcon}`}
                        alt="avatar"
                        className="w-16 rounded-full"
                    />
                </>
            ) : (
                <p>Loading...</p>
            )}
        </div>
    );
}