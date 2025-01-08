import { profileAuthServiceUrl, profileServiceUrl } from "../../env";
import { Profile, ProfileDto } from "../../Entities/BackendEnt";
import axiosInstance from "./axiosInstance";

async function getProfile(profileId: string): Promise<Profile> {
    const result = await axiosInstance.get(profileServiceUrl + '?id=' + profileId);
    return result.data || [];
};

async function postProfile(profile: ProfileDto) {
    await axiosInstance.post(profileServiceUrl + '/createProfile', profile);
}

async function checkIfUserExists(authId: string): Promise<boolean> {
    const result = await axiosInstance.get(profileAuthServiceUrl + '/' + authId);
    return result.data;
}

export const profileService = {
    getProfile,
    postProfile,
    checkIfUserExists
}