/* tslint:disable */
/* eslint-disable */
/**
 * 博客前端接口
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1.0.0
 * 
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */
/**
 * 
 * @export
 * @interface AddCommentInput
 */
export interface AddCommentInput {
    /**
     * 对应模块ID（null表留言，0代表友链的评论）
     * @type {number}
     * @memberof AddCommentInput
     */
    moduleId?: number | null;
    /**
     * 顶级楼层评论ID
     * @type {number}
     * @memberof AddCommentInput
     */
    rootId?: number | null;
    /**
     * 被回复的评论ID
     * @type {number}
     * @memberof AddCommentInput
     */
    parentId?: number | null;
    /**
     * 回复人ID
     * @type {number}
     * @memberof AddCommentInput
     */
    replyAccountId?: number | null;
    /**
     * 评论内容
     * @type {string}
     * @memberof AddCommentInput
     */
    content: string;
}