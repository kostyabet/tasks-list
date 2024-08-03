import "./globals.css";
import {Layout, Menu} from "antd";
import {Content, Header} from "antd/es/layout/layout";
import Link from "next/link";

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
        </Layout>
      </body>
    </html>
  );
}
