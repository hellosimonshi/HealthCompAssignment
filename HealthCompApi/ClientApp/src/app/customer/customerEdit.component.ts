import { Component } from '@angular/core';
//import { HttpClient, HttpParams } from '@angular/common/http';

import { Repository } from "../models/repository";
import { Customer } from '../models/customer.model';

@Component({
  selector: "admin-customer-editor",
  templateUrl: "customerEdit.component.html"
//  styleUrls:
})
export class customerEditComponent {

  constructor(private repo: Repository) { }

  get customer(): Customer {
    return this.repo.customer;
  }
}
