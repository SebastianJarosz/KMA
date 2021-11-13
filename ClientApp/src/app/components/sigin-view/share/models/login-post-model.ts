import { IGlobalItem } from "src/app/shared/interfaces/iglobal-item.models";


export class LoginPost implements IGlobalItem {
    userName?: string;
    password?: string;
    constructor(){
    }

}