import { Routes } from '@angular/router';
import { ProductComponent } from './components/products/product.component';
import { CategoryComponent } from './components/catogry/catogry.component';

export const routes: Routes = [
    { path:'category', component: CategoryComponent },
    { path:'product', component: ProductComponent },
    { path:'**', component: CategoryComponent },

];
