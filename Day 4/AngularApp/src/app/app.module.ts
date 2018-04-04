import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { Router, RouterModule } from "@angular/router";
import { AppComponent } from './app.component';
import { CustomerComponent } from './customer/customer.component';
import { RestaurantComponent } from './restaurant/restaurant.component';
import { HotelService } from './common/hotel.service';
import { HttpModule } from '@angular/http';

const appRoutes =[
  {
    path:'customer',
    component : CustomerComponent
  },
  {
    path:'restaurants',
    component: RestaurantComponent
  }
]

@NgModule({
  declarations: [
    AppComponent,
    CustomerComponent,
    RestaurantComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot(appRoutes, { enableTracing : true})
  ],
  providers: [HotelService],
  bootstrap: [AppComponent]
})
export class AppModule { }
