import { Component, OnInit } from '@angular/core';
import { HotelService } from '../common/hotel.service';
@Component({
  selector: 'app-restaurant',
  templateUrl: './restaurant.component.html',
  styleUrls: ['./restaurant.component.css']
})
export class RestaurantComponent implements OnInit {
  public data = [];
  public customerName : string;
  public customerAddress: string;
  constructor(private myService: HotelService) { }

  ngOnInit() {
    var stored = localStorage.getItem("details");
    var userInfo = JSON.parse(stored);
    this.customerName = userInfo.name;
    this.customerAddress = userInfo.address;
    this.myService.getAllHotels().subscribe(res =>{
       this.data = res; 
    });
  }


}
