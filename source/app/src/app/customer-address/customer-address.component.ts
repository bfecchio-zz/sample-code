import { Component, OnInit, Input } from '@angular/core';
import { CustomerAddress } from '../model/customer-address';

@Component({
  selector: 'app-customer-address',
  templateUrl: './customer-address.component.html',
  styleUrls: ['./customer-address.component.scss']
})
export class CustomerAddressComponent implements OnInit {
  @Input() addresses: [CustomerAddress];

  constructor() { }

  ngOnInit() {
  }

  addAddress() {
    if (!this.addresses) {
      this.addresses = [new CustomerAddress];
      return;
    }

    this.addresses.push(new CustomerAddress());
  }

  deleteAddress(address: CustomerAddress) {        
    this.addresses.splice(this.addresses.indexOf(address), 1);
  }
}
