/* tslint:disable */
/* eslint-disable */
/**
 * 规范化接口演示
 * 让 .NET 开发更简单，更通用，更流行。
 *
 * OpenAPI spec version: 1.0.0
 * Contact: monksoul@outlook.com
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */
import { AvailabilityStatus } from './availability-status';
import { MenuType } from './menu-type';
/**
 * 
 * @export
 * @interface AddSysMenuInput
 */
export interface AddSysMenuInput {
    /**
     * 菜单名称
     * @type {string}
     * @memberof AddSysMenuInput
     */
    name: string;
    /**
     * 
     * @type {MenuType}
     * @memberof AddSysMenuInput
     */
    type?: MenuType;
    /**
     * 权限编码
     * @type {string}
     * @memberof AddSysMenuInput
     */
    code?: string | null;
    /**
     * 父级菜单
     * @type {number}
     * @memberof AddSysMenuInput
     */
    parentId?: number | null;
    /**
     * 路由名
     * @type {string}
     * @memberof AddSysMenuInput
     */
    routeName?: string | null;
    /**
     * 路由地址
     * @type {string}
     * @memberof AddSysMenuInput
     */
    path?: string | null;
    /**
     * 组件路径
     * @type {string}
     * @memberof AddSysMenuInput
     */
    component?: string | null;
    /**
     * 重定向地址
     * @type {string}
     * @memberof AddSysMenuInput
     */
    redirect?: string | null;
    /**
     * 菜单图标
     * @type {string}
     * @memberof AddSysMenuInput
     */
    icon?: string | null;
    /**
     * 是否内嵌页面
     * @type {boolean}
     * @memberof AddSysMenuInput
     */
    isIframe?: boolean;
    /**
     * 外链地址
     * @type {string}
     * @memberof AddSysMenuInput
     */
    link?: string | null;
    /**
     * 是否可见
     * @type {boolean}
     * @memberof AddSysMenuInput
     */
    isVisible?: boolean;
    /**
     * 是否缓存
     * @type {boolean}
     * @memberof AddSysMenuInput
     */
    isKeepAlive?: boolean;
    /**
     * 是否固定
     * @type {boolean}
     * @memberof AddSysMenuInput
     */
    isFixed?: boolean;
    /**
     * 
     * @type {AvailabilityStatus}
     * @memberof AddSysMenuInput
     */
    status?: AvailabilityStatus;
    /**
     * 排序值（值越小越靠前）
     * @type {number}
     * @memberof AddSysMenuInput
     */
    sort?: number;
    /**
     * 备注
     * @type {string}
     * @memberof AddSysMenuInput
     */
    remark?: string | null;
}