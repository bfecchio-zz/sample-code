import localePt from '@angular/common/locales/pt';
import { registerLocaleData } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { LOCALE_ID, NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CustomersComponent } from './customers/customers.component';
import { CustomerAddComponent } from './customer-add/customer-add.component';
import { CustomerEditComponent } from './customer-edit/customer-edit.component';
import { ApiService } from './api.service';
import { CustomerPhoneComponent } from './customer-phone/customer-phone.component';
import { CustomerAddressComponent } from './customer-address/customer-address.component';
import { CustomerTableComponent } from './customer-table/customer-table.component';

registerLocaleData(localePt);

@NgModule({
  declarations: [
    AppComponent,
    CustomersComponent,    
    CustomerAddComponent,
    CustomerEditComponent,
    CustomerPhoneComponent,
    CustomerAddressComponent,
    CustomerTableComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,  
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule,
    NgbModule
  ],
  providers: [{provide: LOCALE_ID, useValue: 'pt'}, ApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
