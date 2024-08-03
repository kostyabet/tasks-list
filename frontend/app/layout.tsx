import "./globals.css";
import {Anchor, Breadcrumb, Layout, Menu} from "antd";
import {Content, Header, Footer} from "antd/es/layout/layout";
import Link from "next/link";
import Home from "@/app/page";

const items = [
  {key: "home", label: <Link href={"/"}>Home</Link>},
  {key: "tasks", label: <Link href={"/tasks"}>Tasks</Link>},
]

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html lang="en">
      <body>
        <Layout style={{minHeight: "100vh"}}>
          <Header>
            <Menu 
                theme="dark" 
                mode="horizontal" 
                items={items} 
                style={{flex: 1, minWidth: 0 }}
            />
          </Header>
          <Content style={{padding: "0 48px"}}>{children}</Content>
          <Footer style={{ textAlign: 'center', width: "auto", flex: 1, height: "100vh", backgroundColor: "rgb(0, 21, 41)", marginTop: "25px", color: "grey"}}>
            <p>Tasks List ©2024 Created by Kostya Betenya</p>
          </Footer>
        </Layout>
      </body>
    </html>
  );
}
