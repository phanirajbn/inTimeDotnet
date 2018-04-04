import { Injectable } from '@angular/core';
import { Http, HttpModule  } from "@angular/http";
import { Observable } from 'rxjs/Observable';
import "rxjs/add/operator/map" ;
@Injectable()
export class HotelService {

  constructor(private http:Http) {

  }

   getAllHotels(): Observable<any>{
     let url = "http://localhost:47005/api/hotel";
       return this.http.get(url).map(res=>{
         let data = res.json();
         return data;
       }) 
   }
}
