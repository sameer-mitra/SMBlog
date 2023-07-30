export class BlogComment{
    constructor(
        public blogCommentId: number,
        public blogId: number,
        public content: string,
        public userName: string,
        public applicationUserId: string,
        public publishDate: Date,
        public updateDate: Date,
        public parentBlogCommentId?: number
    ) { }
}