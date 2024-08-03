import {TaskRequest} from "@/app/services/tasks";
import {Input, Modal} from "antd";
import {useEffect, useState} from "react";
import TextArea from "antd/es/input/TextArea";

interface Props {
    mode: Mode;
    values: Task;
    IsModalOpen: boolean;
    handleCancel: () => void;
    handleCreate: (request: TaskRequest) => void;
    handleUpdate: (id: string, request: TaskRequest) => void;
}

export enum Mode {
    Create,
    Edit,
}

export const CreateUpdateTask = ({
    mode, 
    values, 
    IsModalOpen,
    handleCancel,
    handleCreate,
    handleUpdate,
} : Props) => {
    const [title, setTitle] = useState<string>("");
    const [description, setDescription] = useState<string>("");
    
    useEffect(() => {
        setTitle(values.title);
        setDescription(values.description);
    }, [values]);
    
    const handleOnOk = async () => {
        const taskRequest = {title,  description};
        
        mode == Mode.Create ? handleCreate(taskRequest) : handleUpdate(values.id, taskRequest);
    }
    
    return (
        <Modal 
            title={
                mode == Mode.Create ? "Добавить задачу" : "Редактировать задачу"
            } 
            open={IsModalOpen} 
            cancelText={"Отмена"}
            onOk={handleOnOk}
            onCancel={handleCancel}
        >
            <div className={"book__modal"}>
                <Input
                    value={title}
                    onChange={(e) => setTitle(e.target.value)}
                    placeholder={"Название"}
                />
                <TextArea 
                    value={description}
                    onChange={(e) => setDescription(e.target.value)}
                    autoSize={{ minRows: 3, maxRows: 3 }}
                    placeholder={"Описание"}
                />
            </div>    
        </Modal>
    )
}