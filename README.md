# VB_FinanceSystem

本專案為使用 VB（Visual Basic）搭配 Access 資料庫開發的財務報表管理系統，具備登入、帳號管理、財務登錄、報表匯出與 Email 寄送等功能，適合中小型企業或個人理財記帳使用。

## 💡 開發動機
過去擔任社團總務長時，經常需要手動整理每月的財務收支紀錄與報表，不僅需要反覆輸入金額、摘要與科目，最後結算時還需自行計算收入與支出總額，耗時又容易出錯。因此，我希望透過該方法，開發一套整合式財務報表系統，能夠自動彙整資料、產生報表並寄送審核，大幅減少手動作業的負擔，提升財務管理的效率與準確性。

## 🔧 使用技術
- Visual Basic .NET（WinForms）
- Microsoft Access 資料庫（需安裝 Access Database Engine）
- Word 報表自動匯出
- System.Net.Mail 自動寄送報表功能（SMTP 支援）

## 🖼️ 系統畫面
1. 登入畫面  
   ![image](https://github.com/user-attachments/assets/3580f8a8-9cfa-4e20-9016-346377ab2b65)

2. 財務報表主畫面  
   ![image](https://github.com/user-attachments/assets/cccde931-abc4-42c7-a5b9-71377555a1b6)

3. 註冊畫面  
   ![image](https://github.com/user-attachments/assets/2c0f6855-261a-4423-9c43-fe63b282be3f)

4. 報表匯出畫面（自動產生 Word 檔）  
   ![image](https://github.com/user-attachments/assets/a4dea971-594f-42bd-895c-80a89b25de24)

5. Email 寄送成功提示  
   ![image](https://github.com/user-attachments/assets/9e40d6f1-1225-4cc0-8791-2828bb5f2a46)

## 📌 功能特色
- 🧑‍💼 支援多帳號登入與角色管理（Admin/User）
- 📊 財務資料 CRUD：新增、查詢、修改、刪除
- 🧾 月度報表自動產生（Word 檔）
- 📧 報表可一鍵寄送 Email 附件（支援 Microsoft 帳號）
- 🔐 登入者資訊將自動串接報表與寄件人信箱

## 🗂️ Access 資料表結構
- `FS`：財務資料表（ID, 日期, 科目, 摘要, 收入, 支出, 備註, UserID, 建立日期）  
  ![image](https://github.com/user-attachments/assets/565f01c4-d983-4906-8d23-e238f4ed7c7c)

- `Users`：帳號資訊（UserID, Username, Password, Fullname, Role, Email, EmailPassword）  
  ![image](https://github.com/user-attachments/assets/301dfff0-c95f-421a-8f76-106d37189be8)

## 📁 檔案說明

### `LoginForm.vb`
登入介面，提供以 UserID 或 Username+Password 登入功能，驗證成功後根據使用者角色開啟主畫面並記錄登入者資訊。

### `RegisterForm.vb`
帳號註冊表單，具備帳號重複檢查、基本欄位驗證與註冊後提示功能，支援建立 admin 或 user 身份。

### `Form1.vb`
主系統操作介面，整合以下功能：
- 財務資料新增 / 修改 / 刪除 / 查詢（即時刷新 DataGridView）
- 下拉式選單選擇年與月，自動篩選報表內容
- 報表匯出（Word 檔）：自動命名、計算合計與結餘
- Email 寄送報表：SMTP 寄信、附檔寄送、錯誤處理等完整流程

### `FinanceDB.accdb`
Access 資料庫檔，內含 `Users` 與 `FS` 兩大表格，負責儲存帳號與財務記錄，並支援 SQL 查詢、欄位串接與關聯驗證。

### `xxx公司YYYY年MM月財務報表.docx`
系統產出之 Word 報表範例，自動生成檔名與內容格式。

#### 📄 報表格式說明：
- 標題：「xxx公司YYYY年MM月財務報表」（自動置中）
- 表格欄位：編號、日期、科目、摘要、收入、支出、備註（文字置中、加粗外框）
- 每頁底部自動顯示當頁合計、本頁結餘
- 第二頁起自動接續「上頁結餘」，確保數據一致性

### 📧 Email 報表寄送功能
可將匯出後的財務報表以 Word 附件方式自動寄出，簡化財務文件傳遞流程。

#### 功能特點：
- SMTP 支援（smtp.office365.com，TLS 587）
- 自動抓取登入者的 Email 與密碼進行驗證
- 收件者 Email 可由使用者自行輸入
- 郵件主旨與內文根據報表年月自動生成
- 若檔案不存在或 Email 欄位為空，系統即時提示錯誤訊息

## 🚀 未來可擴充方向展望
- ✅ **圖表視覺化**：新增以圖表呈現財務趨勢（例如圓餅圖、折線圖），提升閱讀性
- ✅ **多人協作與審核流程**：加入報表審核紀錄或審核流程節點，適用於社團或部門內部財務管理
- ✅ **PDF 報表輸出**：除了 Word 格式，也可選擇匯出 PDF 檔案
- ✅ **行動裝置支援**：改寫為 Web 版本或行動裝置介面，方便使用者隨時記帳與查閱
- ✅ **自動備份與雲端同步**：結合雲端資料庫或 OneDrive 自動同步報表，降低資料遺失風險
- ✅ **支援非微軟信箱發送**：讓 Gmail、Yahoo 等平台也能寄送報表（含 OAuth 驗證）

## 📣 備註
本系統為學習與展示用途，非商業應用。如需完整原始碼或進一步了解可聯繫我
📧 jimmy4030565@gmail.com
