import { IGlobalItem } from "src/app/shared/interfaces/iglobal-item.models";

export class UserProfileModel implements IGlobalItem{
    email?: string;
    name?: string;
    surname?: string;
    userName?: string;

    constructor(){}
}