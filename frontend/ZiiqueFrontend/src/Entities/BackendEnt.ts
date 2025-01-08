export interface PaginationFilter {
    page: number;
    pageSize: number;
}

export interface PostEntity {
    id: string;
    title: string;
    content: string;
    createdAt: Date;
    profileId: string;
}

export interface PostCreate {
    title: string;
    content: string;
    createdAt: Date;
}

export interface Posts {
    items: PostEntity[];
    pageNumber: number;
    pageSize: number;
    totalPages: number;
    totalRecords: number;
}

export interface Profile {
    Guid: string;
    username: string;
    displayName: string;
    profileIcon: string;
    bio: string;
    StartedAt: Date;
}

export interface ProfileDto {
    username: string;
    displayName: string;
    profileIcon: string;
    bio: string;
    StartedAt: Date;
}