import { followServiceUrl } from "@/env";
import axiosInstance from "./axiosInstance";

async function followUser(followingId: string) {
    await axiosInstance.post(followServiceUrl + '?followingId=' + followingId);
}

async function unfollowUser(followingId: string) {
    await axiosInstance.delete(followServiceUrl + '?followingId=' + followingId);
}

async function getFollowers() {
    const result = await axiosInstance.get(followServiceUrl);
    return result.data;
}

export const followService = {
    followUser,
    unfollowUser,
    getFollowers
}   