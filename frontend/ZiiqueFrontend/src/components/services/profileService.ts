import axios from "axios";
import { profileServiceUrl } from "../../env";
import { Profile } from "../../Entities/BackendEnt";

async function getProfile(profileId: string): Promise<Profile> {
    const result = await axios.get(profileServiceUrl + '?id=' + profileId);
    return result.data || [];
};

async function postProfile(profile: Profile) {
    await axios.post(profileServiceUrl, profile);
}

export const profileService = {
    getProfile,
    postProfile
}