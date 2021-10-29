import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
//datos
import { todo } from './todo.json';
//subcomponentes
import TodoForm from './components/TodoForm';

class App extends Component {

  constructor() {
    super();
    this.state = {
      todo
    }
    this.handleAddTodo = this.handleAddTodo.bind(this);
  }
  removeTodo(index) {
    this.setState({
      todo: this.state.todo.filter((e, i) => {
        return i !== index
      })
    });
  }

  handleAddTodo(todo) {
    this.setState({
      todo: [...this.state.todo, todo]
    })
  }
  render(){
    const todo =  this.state.todo.map((todo,i)=>{
      return (
        <div className="col-md-4">
          <div className="card mt-4">
            <div className="card-header">
              <h3> {todo.title} </h3>
            <span className="badge rounded-pill bg-info text-dark ml-2">
                {todo.priority}
            </span>
            <span className="badge rounded-pill bg-info text-dark ml-2">
                {todo.State}
            </span>
            </div>
            <div className="card-body">
              <p> {todo.description} </p>
            </div>
            <div className="card-footer">
              <button
                className="btn btn-danger"
                onClick={this.removeTodo.bind(this, i)}>
                Finalizar
              </button>
            </div>
          </div>
        </div>
      )
    })
  return (
    <div className="App">
        <nav className="navbar navbar-dark bg-dark text-white">
          <h6>Documentos Ingresados:
            <span className="badge rounded-pill bg-light text-dark">
              {this.state.todo.length}
            </span></h6>
        </nav>
        <div className="container">
          <div className="row mt-4">
            
          <TodoForm onAddTodo={this.handleAddTodo}></TodoForm>
        </div>
        </div>
        <div className="container">
          <div className="row mt-4">
            {todo}
          </div>
        </div>
        
        <div className="col-md-4 text-center">
          
                <img src={logo} className="App-logo" alt="logo" />
              
        </div>
        
    </div>
    
  );
  }
}

export default App;
