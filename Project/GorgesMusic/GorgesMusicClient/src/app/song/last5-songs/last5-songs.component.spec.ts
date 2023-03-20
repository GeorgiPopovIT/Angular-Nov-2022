import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Last5SongsComponent } from './last5-songs.component';

describe('Last5SongsComponent', () => {
  let component: Last5SongsComponent;
  let fixture: ComponentFixture<Last5SongsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Last5SongsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Last5SongsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
