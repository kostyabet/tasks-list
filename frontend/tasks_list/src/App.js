import {useState} from "react";
import {getAllTasks} from "./services/tasks";

function App() {
  return (
    <div>
      <p>{getAllTasks()}</p>
    </div>
  );
}

export default App;
