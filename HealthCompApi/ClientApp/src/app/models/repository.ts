import { Customer } from "./customer.model";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
//import { Observable } from "rxjs";

const customersUrl = "/api/customers";

@Injectable()
export class Repository {
  customer: Customer;
  customers: Customer[];

  constructor(private http: HttpClient) {
    this.getCustomers();
  }

  getCustomer(id: number) {
    //    this.http.get<Customer>(`${customersUrl}/${id}`).subscribe(c => this.customer = c);
    this.http.get<Customer>(`${customersUrl}/${id}`).subscribe(c => { this.customer = c; console.log('success', c) }, error => console.log('oops', error));
  }

  getCustomers() {
    this.http.get<Customer[]>(customersUrl).subscribe(custs => this.customers = custs);
  }

  createCustomer(cust: Customer) {
    let data = {
      name: cust.name,
      description: cust.description
    };

    this.http.post<number>(customersUrl, data)
      .subscribe(id => {
        cust.id = id;
        this.customers.push(cust);
      }, err => { var t = JSON.parse(JSON.stringify(err)); t['status'] == '400' ? alert(JSON.stringify(t['error'])) : alert("\nYou need login first!!!") });
  }

  updateCustomer(cust: Customer) {
    let data = {
      id: cust.id,
      name: cust.name,
      description: cust.description
    };
    this.http.put(`${customersUrl}/${cust.id}`, data)
      .subscribe(() => this.getCustomers(),
        err => { var t = JSON.parse(JSON.stringify(err)); t['status'] == '400' ? alert(JSON.stringify(t['error'])) : alert("\nYou need login first!!!") });
  }

  deleteCustomer(id: number) {
    this.http.delete(`${customersUrl}/${id}`)
      .subscribe(() => this.getCustomers(), err => alert("FAILED!!!\nYou need login first !!!"));
  }
}
