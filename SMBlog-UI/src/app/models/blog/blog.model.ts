export class Blog{
    constructor(
        public blogId: number,
        public title: number,
        public content: string,
        public applicationUserId: number,
        public userName: string,
        public publishDate: Date,
        public updateDate: Date,
        public deleteConfirm: boolean = false,
        public photoId?: number        
    ) { }
}