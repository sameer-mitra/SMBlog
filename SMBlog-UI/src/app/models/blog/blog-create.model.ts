export class BlogCreate{
    constructor(
        public blogId: number,
        public title: number,
        public content: string,
        public photoId?: number        
    ) { }
}