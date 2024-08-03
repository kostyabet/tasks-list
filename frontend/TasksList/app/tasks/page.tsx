"use client"

import Button from "antd/es/button/button";
import {useEffect, useState} from "react";
import {Tasks} from "./../components/Tasks";
import {createTask, deleteTask, getAllTasks, TaskRequest, updateTask} from "@/app/services/tasks";
import {CreateUpdateTask, Mode} from "@/app/components/CreateUpdateTask";

export default function TasksListPage() {
    const defaultValues = {
        title: "",
        description: "",
    } as Task;
    
    const [values, setValues] = useState<Task>(defaultValues);
    
    const [tasks, setTasks] = useState<Task[]>([]);
    const [loading, setLoading] = useState<boolean>(true);
    const [isModalOpen, setIsModalOpen] = useState<boolean>(false);
    const [mode, setMode] = useState(Mode.Create);
    
    const handleCreateTask = async (request: TaskRequest) => {
        await createTask(request);
        closeModal();
        
        const tasks = await getAllTasks();
        setTasks(tasks);
    }
    
    const handleUpdateTask = async (id: string, request: TaskRequest) => {
        await updateTask(id, request);
        closeModal();

        const tasks = await getAllTasks();
        setTasks(tasks);
    }
    
    const handleDeleteTask = async (id: string) => {
        await deleteTask(id);
        closeModal();
        
        const tasks = await getAllTasks();
        setTasks(tasks);
    }
    
    const openModal = () => {
        setMode(Mode.Create);
        setIsModalOpen(true);
    }
    
    const closeModal = () => {
        setValues(defaultValues);
        setIsModalOpen(false);
    }
    
    const openEditModal = (task: Task) => {
        setMode(Mode.Edit);
        setValues(task);
        setIsModalOpen(true);
    }
    
    useEffect(() => {
        const getTasks = async () => {
            const tasks = await getAllTasks();
            setLoading(false);
            setTasks(tasks);
        };
        
        getTasks();
    }, [])
    
    return (
        <div>
            <Button
                type={"primary"}
                style={{marginTop: "30px"}} 
                size={"large"}
                onClick={openModal}
            >
                Добавить задачу
            </Button>

            <CreateUpdateTask 
                mode={mode} 
                values={values} 
                IsModalOpen={isModalOpen} 
                handleCancel={closeModal} 
                handleCreate={handleCreateTask} 
                handleUpdate={handleUpdateTask}
            />
            
            {loading ? (<title>Loading...</title>) : (<Tasks tasks={tasks} handleOpen={openEditModal} handleDelete={handleDeleteTask}/>)}
        </div>
    )
} 