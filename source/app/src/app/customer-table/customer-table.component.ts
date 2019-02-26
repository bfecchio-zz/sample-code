import { Component, ViewChildren, QueryList } from '@angular/core';
import { Customer } from '../model/customer';
import { NgbdSortableHeader, SortEvent } from './sortable.directive';
import { Observable } from 'rxjs';
import { TableService } from './table.service';
import { ApiService } from '../api.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-customer-table',
  templateUrl: './customer-table.component.html',
  styleUrls: ['./customer-table.component.scss']
})
export class CustomerTableComponent {
  customers$: Observable<Customer[]>;
  total$: Observable<number>;      

  @ViewChildren(NgbdSortableHeader) headers: QueryList<NgbdSortableHeader>;

  constructor(private router: Router, private apiService: ApiService, private tableService: TableService) {
    this.customers$ = tableService.customers$;
    this.total$ = tableService.total$;
  }

  onSort({ column, direction }: SortEvent) {
    // resetting other headers
    this.headers.forEach(header => {
      if (header.sortable !== column) {
        header.direction = '';
      }
    });

    this.tableService.sortColumn = column;
    this.tableService.sortDirection = direction;
  }

  deleteCustomer(customer: Customer): void {
    this.apiService.deleteCustomer(customer)
      .subscribe(_ => this.tableService.onRefresh());
  };

  editCustomer(customer: Customer): void {
    this.router.navigate(['customer-edit', customer.id]);
  };

}
