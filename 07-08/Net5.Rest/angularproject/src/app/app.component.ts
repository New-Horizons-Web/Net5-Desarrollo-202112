import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

    constructor(private http: HttpClient) {
      this.http.get("https://localhost:44325/api/authors?Orderby=age&PageNumber=2&PageSize=2").subscribe(result => {
        console.log(result);
      });      
    }

  title = 'angularproject';


  
}
