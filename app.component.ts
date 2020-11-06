import { Component } from '@angular/core';
import { FormArray, FormControl } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'a';
  hobbies =[
    {
      type: "checkbox",
      name: "car",
      title: "Q1",
      choices: [
          {
            id: 'C009',
            label: 'moto',
            isChecked: false
          },
          {
            id: 'C010',
            label: 'oto',
            isChecked: false
          },
          {
            id: 'C011',
            label: 'bike',
            isChecked: false
          }
      ]
    },
    {
      type: "checkbox",
      name: "car",
      title: "Q2",
      choices: [
          {
            id: 'C009',
            label: 'moto',
            isChecked: false
          },
          {
            id: 'C010',
            label: 'oto',
            isChecked: false
          },
          {
            id: 'C011',
            label: 'bike',
            isChecked: false
          }
      ]
    }
    
  ]
  hobbiesForm: FormArray
  ngOnInit() {
    this.hobbiesForm = new FormArray(this.hobbies.map(x => new FormArray([])))

    //this give so formArray as hobbies you get
    this.hobbies.forEach((x, index) => {  //for each hobiee
        const array=this.hobbiesForm.at(index) as FormArray
        x.choices.forEach(c=>{
          array.push(new FormControl(c.label))
        })
      })
  }

}
