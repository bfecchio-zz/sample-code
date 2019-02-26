import { CustomerAddress } from './customer-address';
import { CustomerPhone } from './customer-phone';

export class Customer {
    id: string;
    name: string;
    birthday: Date;
    address: [CustomerAddress[]];
    phones: [CustomerPhone[]];
    facebook: string;
    linkedin: string;
    twitter: string;
    instagram: string;
    documentId: string;
    socialSecurityId: string;
    dateCreated: Date;
    dateUpdated: Date;
}
