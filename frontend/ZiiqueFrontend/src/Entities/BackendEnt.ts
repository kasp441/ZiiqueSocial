export interface PaginationFilter {
    page: number;
    pageSize: number;
}

export interface PostEntity {
    id: string;
    title: string;
    content: string;
    createdAt: Date;
    profileId: number;
}

export interface PostCreate {
    title: string;
    content: string;
    createdAt: Date;
    profileId: string;
}

export interface Posts {
    items: PostEntity[];
    pageNumber: number;
    pageSize: number;
    totalPages: number;
    totalRecords: number;
}