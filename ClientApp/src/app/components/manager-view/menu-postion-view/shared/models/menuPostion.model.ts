import { Product } from "../../../product-view/shared/models/product.model";

export class MenuPostion{
    name?: string | any;
    menuPostionCode?: string | any;
    unitPrice?: number | any;
    plu?: string | any;
    products?: Array<Product> | any;
}