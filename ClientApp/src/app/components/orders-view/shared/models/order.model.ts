import { IGlobalItem } from "src/app/shared/interfaces/iglobal-item.models"

export class Order implements IGlobalItem{
    orderGuid?: string;
    orderNumber?: number;
    creationTime?: string | any;
    modificationTime?: string | any;
    status?: string;
    orderPostion?: Array<OrderPostion>;

    constructor(){
    }
}

export class OrderPostion{
    menuPostionName?: string;
    menuPostionCode?: string;
    quantityOfMenuPostion?: number;
    isReady?: boolean;
}