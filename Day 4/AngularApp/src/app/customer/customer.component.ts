import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {
  public customerName : string;
  public customerAddress: string;
  constructor() { }

  ngOnInit() {
  }

  onSave(){
    var data = { "name": this.customerName, "address" : this.customerAddress };
    localStorage.setItem("details", JSON.stringify(data));
    alert("Info is stored")
  }
}
