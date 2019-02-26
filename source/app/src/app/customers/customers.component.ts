import { Component, OnInit, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from '../api.service';
import { TableService } from '../customer-table/table.service';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.scss']
})
export class CustomersComponent implements OnInit {      
  constructor(private router: Router, private apiService: ApiService, private tableService: TableService) { }

  ngOnInit() {
    this.tableService.onRefresh();
  }

  addCustomer(): void {
    this.router.navigate(['customer-add']);
  }

}
