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
import { ReplyOutput } from './reply-output';
/**
 * 
 * @export
 * @interface PageResultReplyOutput
 */
export interface PageResultReplyOutput {
    /**
     * 当前页
     * @type {number}
     * @memberof PageResultReplyOutput
     */
    pageNo?: number;
    /**
     * 页容量
     * @type {number}
     * @memberof PageResultReplyOutput
     */
    pageSize?: number;
    /**
     * 总页数
     * @type {number}
     * @memberof PageResultReplyOutput
     */
    pages?: number;
    /**
     * 总条数
     * @type {number}
     * @memberof PageResultReplyOutput
     */
    total?: number;
    /**
     * 数据
     * @type {Array<ReplyOutput>}
     * @memberof PageResultReplyOutput
     */
    rows?: Array<ReplyOutput> | null;
}