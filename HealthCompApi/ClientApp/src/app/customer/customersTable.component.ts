import { Component } from '@angular/core';
import { Repository } from "../models/repository";
import { Customer } from "../models/customer.model";
import { Router } from "@angular/router";

@Component({
  selector: "customers-table",
  templateUrl: "customersTable.component.html"
})
export class customersTableComponent {
  constructor(private repo: Repository, private router: Router)
  { }

  tableMode: boolean = true;

  get customers(): Customer[] {
    return this.repo.customers;
  }

  get customer(): Customer {
    return this.repo.customer;
  }

  selectCustomer(id: number) {
    this.repo.getCustomer(id);
  }

  saveCustomer() {
    if (this.repo.customer.id == null) {
      this.repo.createCustomer(this.repo.customer);
    } else {
      this.repo.updateCustomer(this.repo.customer);
    }
    this.clearCustomer()
    this.tableMode = true;
  }

  deleteCustomer(id: number) {
    this.repo.deleteCustomer(id);
  }

  clearCustomer() {
    this.repo.customer = new Customer();
    this.tableMode = true;
  }
}
