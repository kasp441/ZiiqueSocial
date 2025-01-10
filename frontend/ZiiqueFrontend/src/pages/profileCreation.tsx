import { profileService } from "@/components/services/profileService";
import { ProfileDto } from "@/Entities/BackendEnt";
import { useState } from "react";

export function ProfileCreation() {

    const [profile, setProfile] = useState<ProfileDto>({
        username: '',
        displayName: '',
        profileIcon: '',
        bio: '',
        StartedAt: new Date(),
      });

      // Handle input change
  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
    const { name, value } = e.target;
    setProfile((prevProfile) => ({
      ...prevProfile,
      [name]: value,
    }));
  };

  // Handle form submit
  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    profileService.postProfile(profile);
  };

  return (
    <div>
      <h1>Profile Creation</h1>
      <form onSubmit={handleSubmit}>
      <div>
        <label htmlFor="username">Username:</label>
        <input
          type="text"
          id="username"
          name="username"
          value={profile.username}
          onChange={handleChange}
        />
      </div>
      <div>
        <label htmlFor="displayName">Display Name:</label>
        <input
          type="text"
          id="displayName"
          name="displayName"
          value={profile.displayName}
          onChange={handleChange}
        />
      </div>
      <div>
        <label htmlFor="profileIcon">Profile Icon URL:</label>
        <input
          type="text"
          id="profileIcon"
          name="profileIcon"
          value={profile.profileIcon}
          onChange={handleChange}
        />
      </div>
      <div>
        <label htmlFor="bio">Bio:</label>
        <textarea
          id="bio"
          name="bio"
          value={profile.bio}
          onChange={handleChange}
        />
      </div>
      <div>
        <label htmlFor="StartedAt">Start Date:</label>
        <input
          type="date"
          id="StartedAt"
          name="StartedAt"
          value={profile.StartedAt.toISOString().split('T')[0]}
          onChange={(e) =>
            setProfile((prevProfile) => ({
              ...prevProfile,
              StartedAt: new Date(e.target.value),
            }))
          }
        />
      </div>
      <button type="submit">Submit</button>
    </form>
    </div>
  );
}
