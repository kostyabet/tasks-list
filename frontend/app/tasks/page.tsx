"use client"

import Button from "antd/es/button/button";
import React, {useEffect, useState} from "react";
import {Tasks} from "./../components/Tasks";
import {createTask, deleteTask, getAllTasks, TaskRequest, updateTask} from "@/app/services/tasks";
import {CreateUpdateTask, Mode} from "@/app/components/CreateUpdateTask";
import ErrorLoader from "next/dist/build/webpack/loaders/error-loader";
import {Alert} from "antd";

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
    
    const [alertMessage, setAlertMessage] = useState<string>("");
    
    const handleCreateTask = async (request: TaskRequest) => {
        var requestTask = await createTask(request);
        if (requestTask.status == 200) 
        {
            closeModal();

            const tasks = await getAllTasks();
            setTasks(tasks);
        }
        else 
        {
            setAlertMessage(requestTask.statusText + " Exit code " + requestTask.status);
        }
    }
    
    const handleUpdateTask = async (id: string, request: TaskRequest) => {
        await updateTask(id, request);
        closeModal();

        const tasks = await getAllTasks();
        setTasks(tasks);
    }
    
    const handleDeleteTask = async (id: string) => {
        await deleteTask(id);
                
        const tasks = await getAllTasks();
        setTasks(tasks);
    }
    
    const openModal = () => {
        setAlertMessage("");
        setMode(Mode.Create);
        setIsModalOpen(true);
    }
    
    const closeModal = () => {
        setAlertMessage("");
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
                style={{marginTop: "25px"}} 
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
                alertMessage={alertMessage}
            />
            
            {loading ? (<title>Loading...</title>) : (<Tasks tasks={tasks} handleOpen={openEditModal} handleDelete={handleDeleteTask}/>)}
        </div>
    )
} 