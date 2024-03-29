import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewSongComponent } from './new-song.component';

describe('AddNewSongComponent', () => {
  let component: NewSongComponent;
  let fixture: ComponentFixture<NewSongComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewSongComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NewSongComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
