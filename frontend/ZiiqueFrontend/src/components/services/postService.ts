import { postServiceUrl } from '../../env';
import { Posts, PostCreate, PaginationFilter } from '../../Entities/BackendEnt';
import axiosInstance from './axiosInstance';

async function getPosts(paginationFilter: PaginationFilter): Promise<Posts> {
  const result = await axiosInstance.get(postServiceUrl + '?PageNumber=' + paginationFilter.page + '&PageSize=' + paginationFilter.pageSize);
  return result.data || [];
};

async function getPostsFromUser({ id, paginationFilter }: { id: string; paginationFilter: PaginationFilter }): Promise<Posts> {
  const result = await axiosInstance.get(postServiceUrl + '/' + id + '?PageNumber=' + paginationFilter.page + '&PageSize=' + paginationFilter.pageSize);
  return result.data || [];
};

async function postPost(post: PostCreate) {
  await axiosInstance.post(postServiceUrl, post);
};

export const postService = {
    getPosts,
    getPostsFromUser,
    postPost
};