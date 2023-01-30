import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'angular-uni-beginners';

  onKeyUp(newTitle : string){
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
