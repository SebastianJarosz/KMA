import { IGlobalItem } from "src/app/shared/interfaces/iglobal-item.models";

export class User implements IGlobalItem{
    email?: string;
    name?: string;
    roleName?: string
    surname?: string;
    token?: string;
    userName?: string;

    constructor(){}
}