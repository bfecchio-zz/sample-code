import { Component, OnInit, Input } from '@angular/core';
import { CustomerPhone } from '../model/customer-phone';

@Component({
  selector: 'app-customer-phone',
  templateUrl: './customer-phone.component.html',
  styleUrls: ['./customer-phone.component.scss']
})
export class CustomerPhoneComponent implements OnInit {  
  @Input() phones: [CustomerPhone];

  constructor() { }

  ngOnInit() { }

  addPhone() {
    if (!this.phones) {
      this.phones = [new CustomerPhone];
      return;
    }
    
    this.phones.push(new CustomerPhone());
  }

  deletePhone(phone: CustomerPhone) {        
    this.phones.splice(this.phones.indexOf(phone), 1);
  }
}
