import { Component, OnInit, ViewChild } from '@angular/core';
import { TestComponent } from './test/test.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'angular-uni-beginners';

  @ViewChild(TestComponent)
   test! : TestComponent

  date = new Date();
 
  
  ngOnInit(): void {
    
    setInterval(() => {
         this.date = new Date();
       }, 1);
    }

  onKeyUp(newTitle : string){
    //console.log(this.test);

    this.title = newTitle;
  }
  someChangeApp(word : any){
    console.log('app component');
  }
  h2Classes(){
    return{
      'test' : true
    };
  }
  h2Styles(){
    return {'background' : 'cyan'}
  }
}
