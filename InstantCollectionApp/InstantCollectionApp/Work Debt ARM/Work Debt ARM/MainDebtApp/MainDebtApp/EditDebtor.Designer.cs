namespace MainDebtApp
{
    partial class EditDebtor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label debt_Serial_NumberLabel;
            System.Windows.Forms.Label debt_TypeLabel;
            System.Windows.Forms.Label debtor_Full_NameLabel;
            System.Windows.Forms.Label portfolio_StatusLabel;
            System.Windows.Forms.Label outstanding_PrincipalLabel;
            System.Windows.Forms.Label outstanding_InterestLabel;
            System.Windows.Forms.Label outstanding_PenaltyLabel;
            System.Windows.Forms.Label currencyLabel;
            System.Windows.Forms.Label portfolioLabel;
            System.Windows.Forms.Label debt_CollectorLabel;
            System.Windows.Forms.Label total_OutstandingLabel;
            System.Windows.Forms.Label assigment_DateLabel;
            System.Windows.Forms.Label client_BranchLabel;
            System.Windows.Forms.Label last_Act_typeLabel;
            System.Windows.Forms.Label next_Action_DateLabel;
            System.Windows.Forms.Label clientLabel;
            System.Windows.Forms.Label latest_CommentLabel;
            System.Windows.Forms.Label latest_Person_ContactedLabel;
            System.Windows.Forms.Label reactionLabel;
            System.Windows.Forms.Label contactedViaLabel;
            System.Windows.Forms.Label closeDateLabel;
            System.Windows.Forms.Label branchIdLabel;
            System.Windows.Forms.Label disbursmentDateLabel;
            System.Windows.Forms.Label finishedDateLabel;
            System.Windows.Forms.Label avgMoRepaymentLabel;
            System.Windows.Forms.Label pMTpercentageLabel;
            System.Windows.Forms.Label restructuredContractLabel;
            System.Windows.Forms.Label isRestructuredLabel;
            System.Windows.Forms.Label mortgageLabel;
            System.Windows.Forms.Label pledgeLabel;
            System.Windows.Forms.Label cashColateralLabel;
            System.Windows.Forms.Label contractStatusIdLabel;
            System.Windows.Forms.Label linkIDLabel;
            System.Windows.Forms.Label classificationLabel;
            System.Windows.Forms.Label payAccNoLabel;
            System.Windows.Forms.Label assignmentDebtLabel;
            System.Windows.Forms.Label debt_Id1Label;
            System.Windows.Forms.Label disbursmentAmountLabel;
            System.Windows.Forms.Label inALL_BaseLabel;
            System.Windows.Forms.Label amountInDelayLabel;
            System.Windows.Forms.Label principalDelayLabel;
            System.Windows.Forms.Label interestDelayLabel;
            System.Windows.Forms.Label upComingInterestLabel;
            System.Windows.Forms.Label clientSegmentLabel;
            System.Windows.Forms.Label productIDLabel;
            System.Windows.Forms.Label daysInDelayLabel;
            System.Windows.Forms.Label pTP_AmountLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditDebtor));
            this.usernamesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.forAmazonDataSet = new MainDebtApp.ForAmazonDataSet();
            this.portofolioStatusBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.debtTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.portofolioStatusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.portofolioStatusTableAdapter = new MainDebtApp.ForAmazonDataSetTableAdapters.PortofolioStatusTableAdapter();
            this.usernamesTableAdapter = new MainDebtApp.ForAmazonDataSetTableAdapters.UsernamesTableAdapter();
            this.debtTypeTableAdapter = new MainDebtApp.ForAmazonDataSetTableAdapters.DebtTypeTableAdapter();
            this.label9 = new System.Windows.Forms.Label();
            this.portofolioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.currencyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.currencyTableAdapter = new MainDebtApp.ForAmazonDataSetTableAdapters.CurrencyTableAdapter();
            this.portofolioTableAdapter = new MainDebtApp.ForAmazonDataSetTableAdapters.PortofolioTableAdapter();
            this.debtorsActiveBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.debtorsActiveTableAdapter = new MainDebtApp.ForAmazonDataSetTableAdapters.DebtorsActiveTableAdapter();
            this.tableAdapterManager = new MainDebtApp.ForAmazonDataSetTableAdapters.TableAdapterManager();
            this.debt_Serial_NumberLabel1 = new System.Windows.Forms.Label();
            this.debt_TypeComboBox = new System.Windows.Forms.ComboBox();
            this.debtTypeBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.debtor_Full_NameTextBox = new System.Windows.Forms.TextBox();
            this.portfolio_StatusComboBox = new System.Windows.Forms.ComboBox();
            this.portofolioStatusBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.outstanding_PrincipalTextBox = new System.Windows.Forms.TextBox();
            this.outstanding_InterestTextBox = new System.Windows.Forms.TextBox();
            this.outstanding_PenaltyTextBox = new System.Windows.Forms.TextBox();
            this.currencyComboBox = new System.Windows.Forms.ComboBox();
            this.portfolioTextBox = new System.Windows.Forms.TextBox();
            this.assigment_DateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.client_BranchTextBox = new System.Windows.Forms.TextBox();
            this.last_Act_typeTextBox = new System.Windows.Forms.TextBox();
            this.next_Action_DateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.clientComboBox = new System.Windows.Forms.ComboBox();
            this.clientInstitutionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.latest_CommentTextBox = new System.Windows.Forms.TextBox();
            this.latest_Person_ContactedComboBox = new System.Windows.Forms.ComboBox();
            this.contactedPersonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reactionComboBox = new System.Windows.Forms.ComboBox();
            this.reactionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contactedViaTextBox = new System.Windows.Forms.TextBox();
            this.closeDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.branchIdTextBox = new System.Windows.Forms.TextBox();
            this.disbursmentDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.finishedDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.avgMoRepaymentTextBox = new System.Windows.Forms.TextBox();
            this.pMTpercentageTextBox = new System.Windows.Forms.TextBox();
            this.restructuredContractTextBox = new System.Windows.Forms.TextBox();
            this.isRestructuredTextBox = new System.Windows.Forms.TextBox();
            this.mortgageTextBox = new System.Windows.Forms.TextBox();
            this.pledgeTextBox = new System.Windows.Forms.TextBox();
            this.cashColateralTextBox = new System.Windows.Forms.TextBox();
            this.contractStatusIdTextBox = new System.Windows.Forms.TextBox();
            this.linkIDTextBox = new System.Windows.Forms.TextBox();
            this.classificationTextBox = new System.Windows.Forms.TextBox();
            this.payAccNoTextBox = new System.Windows.Forms.TextBox();
            this.assignmentDebtTextBox = new System.Windows.Forms.TextBox();
            this.debtorsActiveBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.debt_Id1TextBox = new System.Windows.Forms.TextBox();
            this.total_Outstanding1TextBox = new System.Windows.Forms.TextBox();
            this.debtorsActiveBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.debtorsActiveBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.disbursmentAmountTextBox = new System.Windows.Forms.TextBox();
            this.debtorsActiveBindingSource5 = new System.Windows.Forms.BindingSource(this.components);
            this.inALL_BaseTextBox = new System.Windows.Forms.TextBox();
            this.amountInDelayTextBox = new System.Windows.Forms.TextBox();
            this.debtorsActiveBindingSource6 = new System.Windows.Forms.BindingSource(this.components);
            this.principalDelayTextBox = new System.Windows.Forms.TextBox();
            this.debtorsActiveBindingSource7 = new System.Windows.Forms.BindingSource(this.components);
            this.interestDelayTextBox = new System.Windows.Forms.TextBox();
            this.debtorsActiveBindingSource8 = new System.Windows.Forms.BindingSource(this.components);
            this.upComingInterestTextBox = new System.Windows.Forms.TextBox();
            this.debtorsActiveBindingSource9 = new System.Windows.Forms.BindingSource(this.components);
            this.clientSegmentTextBox = new System.Windows.Forms.TextBox();
            this.productIDTextBox = new System.Windows.Forms.TextBox();
            this.daysInDelayTextBox = new System.Windows.Forms.TextBox();
            this.contactedPersonTableAdapter = new MainDebtApp.ForAmazonDataSetTableAdapters.ContactedPersonTableAdapter();
            this.buttonDeleteD = new System.Windows.Forms.Button();
            this.pTP_AmountTextBox = new System.Windows.Forms.TextBox();
            this.debtorsActiveBindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxDCollector = new System.Windows.Forms.ComboBox();
            this.usernamesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.usernamesBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.clientInstitutionTableAdapter = new MainDebtApp.ForAmazonDataSetTableAdapters.ClientInstitutionTableAdapter();
            this.reactionsTableAdapter = new MainDebtApp.ForAmazonDataSetTableAdapters.ReactionsTableAdapter();
            this.textBoxClDate = new System.Windows.Forms.TextBox();
            this.textBoxDbDate = new System.Windows.Forms.TextBox();
            this.textBoxFinDate = new System.Windows.Forms.TextBox();
            this.debtTypeBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.portofolioStatusBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            debt_Serial_NumberLabel = new System.Windows.Forms.Label();
            debt_TypeLabel = new System.Windows.Forms.Label();
            debtor_Full_NameLabel = new System.Windows.Forms.Label();
            portfolio_StatusLabel = new System.Windows.Forms.Label();
            outstanding_PrincipalLabel = new System.Windows.Forms.Label();
            outstanding_InterestLabel = new System.Windows.Forms.Label();
            outstanding_PenaltyLabel = new System.Windows.Forms.Label();
            currencyLabel = new System.Windows.Forms.Label();
            portfolioLabel = new System.Windows.Forms.Label();
            debt_CollectorLabel = new System.Windows.Forms.Label();
            total_OutstandingLabel = new System.Windows.Forms.Label();
            assigment_DateLabel = new System.Windows.Forms.Label();
            client_BranchLabel = new System.Windows.Forms.Label();
            last_Act_typeLabel = new System.Windows.Forms.Label();
            next_Action_DateLabel = new System.Windows.Forms.Label();
            clientLabel = new System.Windows.Forms.Label();
            latest_CommentLabel = new System.Windows.Forms.Label();
            latest_Person_ContactedLabel = new System.Windows.Forms.Label();
            reactionLabel = new System.Windows.Forms.Label();
            contactedViaLabel = new System.Windows.Forms.Label();
            closeDateLabel = new System.Windows.Forms.Label();
            branchIdLabel = new System.Windows.Forms.Label();
            disbursmentDateLabel = new System.Windows.Forms.Label();
            finishedDateLabel = new System.Windows.Forms.Label();
            avgMoRepaymentLabel = new System.Windows.Forms.Label();
            pMTpercentageLabel = new System.Windows.Forms.Label();
            restructuredContractLabel = new System.Windows.Forms.Label();
            isRestructuredLabel = new System.Windows.Forms.Label();
            mortgageLabel = new System.Windows.Forms.Label();
            pledgeLabel = new System.Windows.Forms.Label();
            cashColateralLabel = new System.Windows.Forms.Label();
            contractStatusIdLabel = new System.Windows.Forms.Label();
            linkIDLabel = new System.Windows.Forms.Label();
            classificationLabel = new System.Windows.Forms.Label();
            payAccNoLabel = new System.Windows.Forms.Label();
            assignmentDebtLabel = new System.Windows.Forms.Label();
            debt_Id1Label = new System.Windows.Forms.Label();
            disbursmentAmountLabel = new System.Windows.Forms.Label();
            inALL_BaseLabel = new System.Windows.Forms.Label();
            amountInDelayLabel = new System.Windows.Forms.Label();
            principalDelayLabel = new System.Windows.Forms.Label();
            interestDelayLabel = new System.Windows.Forms.Label();
            upComingInterestLabel = new System.Windows.Forms.Label();
            clientSegmentLabel = new System.Windows.Forms.Label();
            productIDLabel = new System.Windows.Forms.Label();
            daysInDelayLabel = new System.Windows.Forms.Label();
            pTP_AmountLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.usernamesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.forAmazonDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portofolioStatusBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.debtTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portofolioStatusBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portofolioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currencyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.debtorsActiveBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.debtTypeBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portofolioStatusBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientInstitutionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactedPersonBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reactionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.debtorsActiveBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.debtorsActiveBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.debtorsActiveBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.debtorsActiveBindingSource5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.debtorsActiveBindingSource6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.debtorsActiveBindingSource7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.debtorsActiveBindingSource8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.debtorsActiveBindingSource9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.debtorsActiveBindingSource4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usernamesBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usernamesBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.debtTypeBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portofolioStatusBindingSource3)).BeginInit();
            this.SuspendLayout();
            // 
            // debt_Serial_NumberLabel
            // 
            debt_Serial_NumberLabel.AutoSize = true;
            debt_Serial_NumberLabel.Location = new System.Drawing.Point(31, 46);
            debt_Serial_NumberLabel.Name = "debt_Serial_NumberLabel";
            debt_Serial_NumberLabel.Size = new System.Drawing.Size(102, 13);
            debt_Serial_NumberLabel.TabIndex = 80;
            debt_Serial_NumberLabel.Text = "Debt Serial Number:";
            // 
            // debt_TypeLabel
            // 
            debt_TypeLabel.AutoSize = true;
            debt_TypeLabel.Location = new System.Drawing.Point(31, 98);
            debt_TypeLabel.Name = "debt_TypeLabel";
            debt_TypeLabel.Size = new System.Drawing.Size(60, 13);
            debt_TypeLabel.TabIndex = 84;
            debt_TypeLabel.Text = "Debt Type:";
            // 
            // debtor_Full_NameLabel
            // 
            debtor_Full_NameLabel.AutoSize = true;
            debtor_Full_NameLabel.Location = new System.Drawing.Point(31, 125);
            debtor_Full_NameLabel.Name = "debtor_Full_NameLabel";
            debtor_Full_NameLabel.Size = new System.Drawing.Size(92, 13);
            debtor_Full_NameLabel.TabIndex = 86;
            debtor_Full_NameLabel.Text = "Debtor Full Name:";
            // 
            // portfolio_StatusLabel
            // 
            portfolio_StatusLabel.AutoSize = true;
            portfolio_StatusLabel.Location = new System.Drawing.Point(31, 151);
            portfolio_StatusLabel.Name = "portfolio_StatusLabel";
            portfolio_StatusLabel.Size = new System.Drawing.Size(81, 13);
            portfolio_StatusLabel.TabIndex = 88;
            portfolio_StatusLabel.Text = "Portfolio Status:";
            // 
            // outstanding_PrincipalLabel
            // 
            outstanding_PrincipalLabel.AutoSize = true;
            outstanding_PrincipalLabel.Location = new System.Drawing.Point(31, 178);
            outstanding_PrincipalLabel.Name = "outstanding_PrincipalLabel";
            outstanding_PrincipalLabel.Size = new System.Drawing.Size(110, 13);
            outstanding_PrincipalLabel.TabIndex = 90;
            outstanding_PrincipalLabel.Text = "Outstanding Principal:";
            // 
            // outstanding_InterestLabel
            // 
            outstanding_InterestLabel.AutoSize = true;
            outstanding_InterestLabel.Location = new System.Drawing.Point(31, 204);
            outstanding_InterestLabel.Name = "outstanding_InterestLabel";
            outstanding_InterestLabel.Size = new System.Drawing.Size(105, 13);
            outstanding_InterestLabel.TabIndex = 92;
            outstanding_InterestLabel.Text = "Outstanding Interest:";
            // 
            // outstanding_PenaltyLabel
            // 
            outstanding_PenaltyLabel.AutoSize = true;
            outstanding_PenaltyLabel.Location = new System.Drawing.Point(31, 230);
            outstanding_PenaltyLabel.Name = "outstanding_PenaltyLabel";
            outstanding_PenaltyLabel.Size = new System.Drawing.Size(105, 13);
            outstanding_PenaltyLabel.TabIndex = 94;
            outstanding_PenaltyLabel.Text = "Outstanding Penalty:";
            // 
            // currencyLabel
            // 
            currencyLabel.AutoSize = true;
            currencyLabel.Location = new System.Drawing.Point(31, 256);
            currencyLabel.Name = "currencyLabel";
            currencyLabel.Size = new System.Drawing.Size(52, 13);
            currencyLabel.TabIndex = 96;
            currencyLabel.Text = "Currency:";
            // 
            // portfolioLabel
            // 
            portfolioLabel.AutoSize = true;
            portfolioLabel.Location = new System.Drawing.Point(31, 283);
            portfolioLabel.Name = "portfolioLabel";
            portfolioLabel.Size = new System.Drawing.Size(48, 13);
            portfolioLabel.TabIndex = 98;
            portfolioLabel.Text = "Portfolio:";
            // 
            // debt_CollectorLabel
            // 
            debt_CollectorLabel.AutoSize = true;
            debt_CollectorLabel.Location = new System.Drawing.Point(31, 309);
            debt_CollectorLabel.Name = "debt_CollectorLabel";
            debt_CollectorLabel.Size = new System.Drawing.Size(77, 13);
            debt_CollectorLabel.TabIndex = 100;
            debt_CollectorLabel.Text = "Debt Collector:";
            // 
            // total_OutstandingLabel
            // 
            total_OutstandingLabel.AutoSize = true;
            total_OutstandingLabel.Location = new System.Drawing.Point(31, 335);
            total_OutstandingLabel.Name = "total_OutstandingLabel";
            total_OutstandingLabel.Size = new System.Drawing.Size(94, 13);
            total_OutstandingLabel.TabIndex = 102;
            total_OutstandingLabel.Text = "Total Outstanding:";
            // 
            // assigment_DateLabel
            // 
            assigment_DateLabel.AutoSize = true;
            assigment_DateLabel.Location = new System.Drawing.Point(31, 362);
            assigment_DateLabel.Name = "assigment_DateLabel";
            assigment_DateLabel.Size = new System.Drawing.Size(84, 13);
            assigment_DateLabel.TabIndex = 104;
            assigment_DateLabel.Text = "Assigment Date:";
            // 
            // client_BranchLabel
            // 
            client_BranchLabel.AutoSize = true;
            client_BranchLabel.Location = new System.Drawing.Point(31, 387);
            client_BranchLabel.Name = "client_BranchLabel";
            client_BranchLabel.Size = new System.Drawing.Size(73, 13);
            client_BranchLabel.TabIndex = 106;
            client_BranchLabel.Text = "Client Branch:";
            // 
            // last_Act_typeLabel
            // 
            last_Act_typeLabel.AutoSize = true;
            last_Act_typeLabel.Location = new System.Drawing.Point(32, 414);
            last_Act_typeLabel.Name = "last_Act_typeLabel";
            last_Act_typeLabel.Size = new System.Drawing.Size(72, 13);
            last_Act_typeLabel.TabIndex = 112;
            last_Act_typeLabel.Text = "Last Act type:";
            // 
            // next_Action_DateLabel
            // 
            next_Action_DateLabel.AutoSize = true;
            next_Action_DateLabel.Location = new System.Drawing.Point(32, 441);
            next_Action_DateLabel.Name = "next_Action_DateLabel";
            next_Action_DateLabel.Size = new System.Drawing.Size(91, 13);
            next_Action_DateLabel.TabIndex = 114;
            next_Action_DateLabel.Text = "Next Action Date:";
            // 
            // clientLabel
            // 
            clientLabel.AutoSize = true;
            clientLabel.Location = new System.Drawing.Point(32, 466);
            clientLabel.Name = "clientLabel";
            clientLabel.Size = new System.Drawing.Size(36, 13);
            clientLabel.TabIndex = 116;
            clientLabel.Text = "Client:";
            // 
            // latest_CommentLabel
            // 
            latest_CommentLabel.AutoSize = true;
            latest_CommentLabel.Location = new System.Drawing.Point(32, 493);
            latest_CommentLabel.Name = "latest_CommentLabel";
            latest_CommentLabel.Size = new System.Drawing.Size(86, 13);
            latest_CommentLabel.TabIndex = 118;
            latest_CommentLabel.Text = "Latest Comment:";
            // 
            // latest_Person_ContactedLabel
            // 
            latest_Person_ContactedLabel.AutoSize = true;
            latest_Person_ContactedLabel.Location = new System.Drawing.Point(32, 519);
            latest_Person_ContactedLabel.Name = "latest_Person_ContactedLabel";
            latest_Person_ContactedLabel.Size = new System.Drawing.Size(127, 13);
            latest_Person_ContactedLabel.TabIndex = 120;
            latest_Person_ContactedLabel.Text = "Latest Person Contacted:";
            // 
            // reactionLabel
            // 
            reactionLabel.AutoSize = true;
            reactionLabel.Location = new System.Drawing.Point(32, 546);
            reactionLabel.Name = "reactionLabel";
            reactionLabel.Size = new System.Drawing.Size(53, 13);
            reactionLabel.TabIndex = 122;
            reactionLabel.Text = "Reaction:";
            // 
            // contactedViaLabel
            // 
            contactedViaLabel.AutoSize = true;
            contactedViaLabel.Location = new System.Drawing.Point(32, 573);
            contactedViaLabel.Name = "contactedViaLabel";
            contactedViaLabel.Size = new System.Drawing.Size(77, 13);
            contactedViaLabel.TabIndex = 124;
            contactedViaLabel.Text = "Contacted Via:";
            // 
            // closeDateLabel
            // 
            closeDateLabel.AutoSize = true;
            closeDateLabel.Location = new System.Drawing.Point(32, 605);
            closeDateLabel.Name = "closeDateLabel";
            closeDateLabel.Size = new System.Drawing.Size(62, 13);
            closeDateLabel.TabIndex = 128;
            closeDateLabel.Text = "Close Date:";
            // 
            // branchIdLabel
            // 
            branchIdLabel.AutoSize = true;
            branchIdLabel.Location = new System.Drawing.Point(418, 147);
            branchIdLabel.Name = "branchIdLabel";
            branchIdLabel.Size = new System.Drawing.Size(56, 13);
            branchIdLabel.TabIndex = 130;
            branchIdLabel.Text = "Branch Id:";
            // 
            // disbursmentDateLabel
            // 
            disbursmentDateLabel.AutoSize = true;
            disbursmentDateLabel.Location = new System.Drawing.Point(30, 635);
            disbursmentDateLabel.Name = "disbursmentDateLabel";
            disbursmentDateLabel.Size = new System.Drawing.Size(94, 13);
            disbursmentDateLabel.TabIndex = 132;
            disbursmentDateLabel.Text = "Disbursment Date:";
            // 
            // finishedDateLabel
            // 
            finishedDateLabel.AutoSize = true;
            finishedDateLabel.Location = new System.Drawing.Point(30, 661);
            finishedDateLabel.Name = "finishedDateLabel";
            finishedDateLabel.Size = new System.Drawing.Size(75, 13);
            finishedDateLabel.TabIndex = 134;
            finishedDateLabel.Text = "Finished Date:";
            // 
            // avgMoRepaymentLabel
            // 
            avgMoRepaymentLabel.AutoSize = true;
            avgMoRepaymentLabel.Location = new System.Drawing.Point(419, 542);
            avgMoRepaymentLabel.Name = "avgMoRepaymentLabel";
            avgMoRepaymentLabel.Size = new System.Drawing.Size(104, 13);
            avgMoRepaymentLabel.TabIndex = 140;
            avgMoRepaymentLabel.Text = "Avg Mo Repayment:";
            // 
            // pMTpercentageLabel
            // 
            pMTpercentageLabel.AutoSize = true;
            pMTpercentageLabel.Location = new System.Drawing.Point(419, 568);
            pMTpercentageLabel.Name = "pMTpercentageLabel";
            pMTpercentageLabel.Size = new System.Drawing.Size(87, 13);
            pMTpercentageLabel.TabIndex = 142;
            pMTpercentageLabel.Text = "PMTpercentage:";
            // 
            // restructuredContractLabel
            // 
            restructuredContractLabel.AutoSize = true;
            restructuredContractLabel.Location = new System.Drawing.Point(418, 594);
            restructuredContractLabel.Name = "restructuredContractLabel";
            restructuredContractLabel.Size = new System.Drawing.Size(114, 13);
            restructuredContractLabel.TabIndex = 144;
            restructuredContractLabel.Text = "Restructured Contract:";
            // 
            // isRestructuredLabel
            // 
            isRestructuredLabel.AutoSize = true;
            isRestructuredLabel.Location = new System.Drawing.Point(418, 620);
            isRestructuredLabel.Name = "isRestructuredLabel";
            isRestructuredLabel.Size = new System.Drawing.Size(82, 13);
            isRestructuredLabel.TabIndex = 146;
            isRestructuredLabel.Text = "Is Restructured:";
            // 
            // mortgageLabel
            // 
            mortgageLabel.AutoSize = true;
            mortgageLabel.Location = new System.Drawing.Point(419, 46);
            mortgageLabel.Name = "mortgageLabel";
            mortgageLabel.Size = new System.Drawing.Size(55, 13);
            mortgageLabel.TabIndex = 198;
            mortgageLabel.Text = "Mortgage:";
            // 
            // pledgeLabel
            // 
            pledgeLabel.AutoSize = true;
            pledgeLabel.Location = new System.Drawing.Point(419, 72);
            pledgeLabel.Name = "pledgeLabel";
            pledgeLabel.Size = new System.Drawing.Size(43, 13);
            pledgeLabel.TabIndex = 200;
            pledgeLabel.Text = "Pledge:";
            // 
            // cashColateralLabel
            // 
            cashColateralLabel.AutoSize = true;
            cashColateralLabel.Location = new System.Drawing.Point(419, 98);
            cashColateralLabel.Name = "cashColateralLabel";
            cashColateralLabel.Size = new System.Drawing.Size(78, 13);
            cashColateralLabel.TabIndex = 202;
            cashColateralLabel.Text = "Cash Colateral:";
            // 
            // contractStatusIdLabel
            // 
            contractStatusIdLabel.AutoSize = true;
            contractStatusIdLabel.Location = new System.Drawing.Point(419, 124);
            contractStatusIdLabel.Name = "contractStatusIdLabel";
            contractStatusIdLabel.Size = new System.Drawing.Size(95, 13);
            contractStatusIdLabel.TabIndex = 204;
            contractStatusIdLabel.Text = "Contract Status Id:";
            // 
            // linkIDLabel
            // 
            linkIDLabel.AutoSize = true;
            linkIDLabel.Location = new System.Drawing.Point(419, 176);
            linkIDLabel.Name = "linkIDLabel";
            linkIDLabel.Size = new System.Drawing.Size(44, 13);
            linkIDLabel.TabIndex = 208;
            linkIDLabel.Text = "Link ID:";
            // 
            // classificationLabel
            // 
            classificationLabel.AutoSize = true;
            classificationLabel.Location = new System.Drawing.Point(419, 202);
            classificationLabel.Name = "classificationLabel";
            classificationLabel.Size = new System.Drawing.Size(71, 13);
            classificationLabel.TabIndex = 210;
            classificationLabel.Text = "Classification:";
            // 
            // payAccNoLabel
            // 
            payAccNoLabel.AutoSize = true;
            payAccNoLabel.Location = new System.Drawing.Point(419, 228);
            payAccNoLabel.Name = "payAccNoLabel";
            payAccNoLabel.Size = new System.Drawing.Size(67, 13);
            payAccNoLabel.TabIndex = 212;
            payAccNoLabel.Text = "Pay Acc No:";
            // 
            // assignmentDebtLabel
            // 
            assignmentDebtLabel.AutoSize = true;
            assignmentDebtLabel.Location = new System.Drawing.Point(419, 254);
            assignmentDebtLabel.Name = "assignmentDebtLabel";
            assignmentDebtLabel.Size = new System.Drawing.Size(90, 13);
            assignmentDebtLabel.TabIndex = 214;
            assignmentDebtLabel.Text = "Assignment Debt:";
            // 
            // debt_Id1Label
            // 
            debt_Id1Label.AutoSize = true;
            debt_Id1Label.Location = new System.Drawing.Point(34, 72);
            debt_Id1Label.Name = "debt_Id1Label";
            debt_Id1Label.Size = new System.Drawing.Size(45, 13);
            debt_Id1Label.TabIndex = 216;
            debt_Id1Label.Text = "Debt Id:";
            // 
            // disbursmentAmountLabel
            // 
            disbursmentAmountLabel.AutoSize = true;
            disbursmentAmountLabel.Location = new System.Drawing.Point(419, 306);
            disbursmentAmountLabel.Name = "disbursmentAmountLabel";
            disbursmentAmountLabel.Size = new System.Drawing.Size(107, 13);
            disbursmentAmountLabel.TabIndex = 230;
            disbursmentAmountLabel.Text = "Disbursment Amount:";
            // 
            // inALL_BaseLabel
            // 
            inALL_BaseLabel.AutoSize = true;
            inALL_BaseLabel.Location = new System.Drawing.Point(419, 332);
            inALL_BaseLabel.Name = "inALL_BaseLabel";
            inALL_BaseLabel.Size = new System.Drawing.Size(68, 13);
            inALL_BaseLabel.TabIndex = 232;
            inALL_BaseLabel.Text = "In ALL Base:";
            // 
            // amountInDelayLabel
            // 
            amountInDelayLabel.AutoSize = true;
            amountInDelayLabel.Location = new System.Drawing.Point(419, 358);
            amountInDelayLabel.Name = "amountInDelayLabel";
            amountInDelayLabel.Size = new System.Drawing.Size(88, 13);
            amountInDelayLabel.TabIndex = 234;
            amountInDelayLabel.Text = "Amount In Delay:";
            // 
            // principalDelayLabel
            // 
            principalDelayLabel.AutoSize = true;
            principalDelayLabel.Location = new System.Drawing.Point(419, 384);
            principalDelayLabel.Name = "principalDelayLabel";
            principalDelayLabel.Size = new System.Drawing.Size(80, 13);
            principalDelayLabel.TabIndex = 236;
            principalDelayLabel.Text = "Principal Delay:";
            // 
            // interestDelayLabel
            // 
            interestDelayLabel.AutoSize = true;
            interestDelayLabel.Location = new System.Drawing.Point(419, 410);
            interestDelayLabel.Name = "interestDelayLabel";
            interestDelayLabel.Size = new System.Drawing.Size(75, 13);
            interestDelayLabel.TabIndex = 238;
            interestDelayLabel.Text = "Interest Delay:";
            // 
            // upComingInterestLabel
            // 
            upComingInterestLabel.AutoSize = true;
            upComingInterestLabel.Location = new System.Drawing.Point(419, 436);
            upComingInterestLabel.Name = "upComingInterestLabel";
            upComingInterestLabel.Size = new System.Drawing.Size(100, 13);
            upComingInterestLabel.TabIndex = 240;
            upComingInterestLabel.Text = "Up Coming Interest:";
            // 
            // clientSegmentLabel
            // 
            clientSegmentLabel.AutoSize = true;
            clientSegmentLabel.Location = new System.Drawing.Point(419, 462);
            clientSegmentLabel.Name = "clientSegmentLabel";
            clientSegmentLabel.Size = new System.Drawing.Size(81, 13);
            clientSegmentLabel.TabIndex = 242;
            clientSegmentLabel.Text = "Client Segment:";
            // 
            // productIDLabel
            // 
            productIDLabel.AutoSize = true;
            productIDLabel.Location = new System.Drawing.Point(419, 488);
            productIDLabel.Name = "productIDLabel";
            productIDLabel.Size = new System.Drawing.Size(61, 13);
            productIDLabel.TabIndex = 244;
            productIDLabel.Text = "Product ID:";
            // 
            // daysInDelayLabel
            // 
            daysInDelayLabel.AutoSize = true;
            daysInDelayLabel.Location = new System.Drawing.Point(419, 514);
            daysInDelayLabel.Name = "daysInDelayLabel";
            daysInDelayLabel.Size = new System.Drawing.Size(76, 13);
            daysInDelayLabel.TabIndex = 246;
            daysInDelayLabel.Text = "Days In Delay:";
            // 
            // pTP_AmountLabel
            // 
            pTP_AmountLabel.AutoSize = true;
            pTP_AmountLabel.Location = new System.Drawing.Point(418, 279);
            pTP_AmountLabel.Name = "pTP_AmountLabel";
            pTP_AmountLabel.Size = new System.Drawing.Size(70, 13);
            pTP_AmountLabel.TabIndex = 249;
            pTP_AmountLabel.Text = "PTP Amount:";
            // 
            // usernamesBindingSource
            // 
            this.usernamesBindingSource.DataMember = "Usernames";
            this.usernamesBindingSource.DataSource = this.forAmazonDataSet;
            // 
            // forAmazonDataSet
            // 
            this.forAmazonDataSet.DataSetName = "ForAmazonDataSet";
            this.forAmazonDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // portofolioStatusBindingSource1
            // 
            this.portofolioStatusBindingSource1.DataMember = "PortofolioStatus";
            this.portofolioStatusBindingSource1.DataSource = this.forAmazonDataSet;
            // 
            // debtTypeBindingSource
            // 
            this.debtTypeBindingSource.DataMember = "DebtType";
            this.debtTypeBindingSource.DataSource = this.forAmazonDataSet;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button1.Location = new System.Drawing.Point(556, 677);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 27);
            this.button1.TabIndex = 72;
            this.button1.Text = "Save changes";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxPass
            // 
            this.textBoxPass.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPass.Location = new System.Drawing.Point(556, 649);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.PasswordChar = '*';
            this.textBoxPass.Size = new System.Drawing.Size(200, 20);
            this.textBoxPass.TabIndex = 74;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(418, 652);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 15);
            this.label8.TabIndex = 73;
            this.label8.Text = "Password:";
            // 
            // portofolioStatusBindingSource
            // 
            this.portofolioStatusBindingSource.DataMember = "PortofolioStatus";
            this.portofolioStatusBindingSource.DataSource = this.forAmazonDataSet;
            // 
            // portofolioStatusTableAdapter
            // 
            this.portofolioStatusTableAdapter.ClearBeforeFill = true;
            // 
            // usernamesTableAdapter
            // 
            this.usernamesTableAdapter.ClearBeforeFill = true;
            // 
            // debtTypeTableAdapter
            // 
            this.debtTypeTableAdapter.ClearBeforeFill = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Location = new System.Drawing.Point(298, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 23);
            this.label9.TabIndex = 75;
            this.label9.Text = "Edit Debtor";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // portofolioBindingSource
            // 
            this.portofolioBindingSource.DataMember = "Portofolio";
            this.portofolioBindingSource.DataSource = this.forAmazonDataSet;
            // 
            // currencyBindingSource
            // 
            this.currencyBindingSource.DataMember = "Currency";
            this.currencyBindingSource.DataSource = this.forAmazonDataSet;
            // 
            // currencyTableAdapter
            // 
            this.currencyTableAdapter.ClearBeforeFill = true;
            // 
            // portofolioTableAdapter
            // 
            this.portofolioTableAdapter.ClearBeforeFill = true;
            // 
            // debtorsActiveBindingSource
            // 
            this.debtorsActiveBindingSource.DataMember = "DebtorsActive";
            this.debtorsActiveBindingSource.DataSource = this.forAmazonDataSet;
            // 
            // debtorsActiveTableAdapter
            // 
            this.debtorsActiveTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.ActionsJanTableAdapter = null;
            this.tableAdapterManager.ActionTypeTableAdapter = null;
            this.tableAdapterManager.AppVersionTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BillsTableAdapter = null;
            this.tableAdapterManager.ClientInstitutionTableAdapter = null;
            this.tableAdapterManager.CollateralsTableAdapter = null;
            this.tableAdapterManager.ContactedPersonTableAdapter = null;
            this.tableAdapterManager.CurrencyTableAdapter = this.currencyTableAdapter;
            this.tableAdapterManager.DebtorsActiveTableAdapter = this.debtorsActiveTableAdapter;
            this.tableAdapterManager.DebtTypeTableAdapter = this.debtTypeTableAdapter;
            this.tableAdapterManager.FeedbackTabTableAdapter = null;
            this.tableAdapterManager.NotificationsTableAdapter = null;
            this.tableAdapterManager.ObjektivatTableAdapter = null;
            this.tableAdapterManager.PaymentsJanTableAdapter = null;
            this.tableAdapterManager.PersonsTableAdapter = null;
            this.tableAdapterManager.PortofolioStatusTableAdapter = this.portofolioStatusTableAdapter;
            this.tableAdapterManager.PortofolioTableAdapter = this.portofolioTableAdapter;
            this.tableAdapterManager.ReactionsTableAdapter = null;
            this.tableAdapterManager.TasksTableAdapter = null;
            this.tableAdapterManager.TempPaymentsTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = MainDebtApp.ForAmazonDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UsernamesTableAdapter = this.usernamesTableAdapter;
            // 
            // debt_Serial_NumberLabel1
            // 
            this.debt_Serial_NumberLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource, "Debt_Serial_Number", true));
            this.debt_Serial_NumberLabel1.Location = new System.Drawing.Point(169, 46);
            this.debt_Serial_NumberLabel1.Name = "debt_Serial_NumberLabel1";
            this.debt_Serial_NumberLabel1.Size = new System.Drawing.Size(200, 23);
            this.debt_Serial_NumberLabel1.TabIndex = 81;
            this.debt_Serial_NumberLabel1.Text = "label6";
            // 
            // debt_TypeComboBox
            // 
            this.debt_TypeComboBox.DataSource = this.debtTypeBindingSource2;
            this.debt_TypeComboBox.DisplayMember = "Debt_type";
            this.debt_TypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.debt_TypeComboBox.FormattingEnabled = true;
            this.debt_TypeComboBox.Location = new System.Drawing.Point(169, 95);
            this.debt_TypeComboBox.Name = "debt_TypeComboBox";
            this.debt_TypeComboBox.Size = new System.Drawing.Size(200, 21);
            this.debt_TypeComboBox.TabIndex = 85;
            this.debt_TypeComboBox.ValueMember = "Debt_type";
            // 
            // debtTypeBindingSource1
            // 
            this.debtTypeBindingSource1.DataMember = "DebtType";
            this.debtTypeBindingSource1.DataSource = this.forAmazonDataSet;
            // 
            // debtor_Full_NameTextBox
            // 
            this.debtor_Full_NameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource, "Debtor_Full_Name", true));
            this.debtor_Full_NameTextBox.Location = new System.Drawing.Point(169, 122);
            this.debtor_Full_NameTextBox.Name = "debtor_Full_NameTextBox";
            this.debtor_Full_NameTextBox.Size = new System.Drawing.Size(200, 20);
            this.debtor_Full_NameTextBox.TabIndex = 87;
            // 
            // portfolio_StatusComboBox
            // 
            this.portfolio_StatusComboBox.DataSource = this.portofolioStatusBindingSource3;
            this.portfolio_StatusComboBox.DisplayMember = "Protofolio_status";
            this.portfolio_StatusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portfolio_StatusComboBox.FormattingEnabled = true;
            this.portfolio_StatusComboBox.Location = new System.Drawing.Point(169, 148);
            this.portfolio_StatusComboBox.Name = "portfolio_StatusComboBox";
            this.portfolio_StatusComboBox.Size = new System.Drawing.Size(200, 21);
            this.portfolio_StatusComboBox.TabIndex = 89;
            this.portfolio_StatusComboBox.ValueMember = "Protofolio_status";
            // 
            // portofolioStatusBindingSource2
            // 
            this.portofolioStatusBindingSource2.DataMember = "PortofolioStatus";
            this.portofolioStatusBindingSource2.DataSource = this.forAmazonDataSet;
            // 
            // outstanding_PrincipalTextBox
            // 
            this.outstanding_PrincipalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource, "Outstanding_Principal", true));
            this.outstanding_PrincipalTextBox.Location = new System.Drawing.Point(169, 175);
            this.outstanding_PrincipalTextBox.Name = "outstanding_PrincipalTextBox";
            this.outstanding_PrincipalTextBox.Size = new System.Drawing.Size(200, 20);
            this.outstanding_PrincipalTextBox.TabIndex = 91;
            // 
            // outstanding_InterestTextBox
            // 
            this.outstanding_InterestTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource, "Outstanding_Interest", true));
            this.outstanding_InterestTextBox.Location = new System.Drawing.Point(169, 201);
            this.outstanding_InterestTextBox.Name = "outstanding_InterestTextBox";
            this.outstanding_InterestTextBox.Size = new System.Drawing.Size(200, 20);
            this.outstanding_InterestTextBox.TabIndex = 93;
            // 
            // outstanding_PenaltyTextBox
            // 
            this.outstanding_PenaltyTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource, "Outstanding_Penalty", true));
            this.outstanding_PenaltyTextBox.Location = new System.Drawing.Point(169, 227);
            this.outstanding_PenaltyTextBox.Name = "outstanding_PenaltyTextBox";
            this.outstanding_PenaltyTextBox.Size = new System.Drawing.Size(200, 20);
            this.outstanding_PenaltyTextBox.TabIndex = 95;
            // 
            // currencyComboBox
            // 
            this.currencyComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource, "Currency", true));
            this.currencyComboBox.DataSource = this.currencyBindingSource;
            this.currencyComboBox.DisplayMember = "Currency";
            this.currencyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.currencyComboBox.FormattingEnabled = true;
            this.currencyComboBox.Location = new System.Drawing.Point(169, 253);
            this.currencyComboBox.Name = "currencyComboBox";
            this.currencyComboBox.Size = new System.Drawing.Size(200, 21);
            this.currencyComboBox.TabIndex = 97;
            this.currencyComboBox.ValueMember = "Currency";
            // 
            // portfolioTextBox
            // 
            this.portfolioTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource, "Portfolio", true));
            this.portfolioTextBox.Location = new System.Drawing.Point(169, 280);
            this.portfolioTextBox.Name = "portfolioTextBox";
            this.portfolioTextBox.Size = new System.Drawing.Size(200, 20);
            this.portfolioTextBox.TabIndex = 99;
            // 
            // assigment_DateDateTimePicker
            // 
            this.assigment_DateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.debtorsActiveBindingSource, "Assigment_Date", true));
            this.assigment_DateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.assigment_DateDateTimePicker.Location = new System.Drawing.Point(169, 358);
            this.assigment_DateDateTimePicker.Name = "assigment_DateDateTimePicker";
            this.assigment_DateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.assigment_DateDateTimePicker.TabIndex = 105;
            // 
            // client_BranchTextBox
            // 
            this.client_BranchTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource, "Client_Branch", true));
            this.client_BranchTextBox.Location = new System.Drawing.Point(169, 384);
            this.client_BranchTextBox.Name = "client_BranchTextBox";
            this.client_BranchTextBox.Size = new System.Drawing.Size(200, 20);
            this.client_BranchTextBox.TabIndex = 107;
            // 
            // last_Act_typeTextBox
            // 
            this.last_Act_typeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource, "Last_Act_type", true));
            this.last_Act_typeTextBox.Location = new System.Drawing.Point(170, 411);
            this.last_Act_typeTextBox.Name = "last_Act_typeTextBox";
            this.last_Act_typeTextBox.Size = new System.Drawing.Size(200, 20);
            this.last_Act_typeTextBox.TabIndex = 113;
            // 
            // next_Action_DateDateTimePicker
            // 
            this.next_Action_DateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.debtorsActiveBindingSource, "Next_Action_Date", true));
            this.next_Action_DateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.next_Action_DateDateTimePicker.Location = new System.Drawing.Point(170, 437);
            this.next_Action_DateDateTimePicker.Name = "next_Action_DateDateTimePicker";
            this.next_Action_DateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.next_Action_DateDateTimePicker.TabIndex = 115;
            // 
            // clientComboBox
            // 
            this.clientComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource, "Client", true));
            this.clientComboBox.DataSource = this.clientInstitutionBindingSource;
            this.clientComboBox.DisplayMember = "Client_Institution";
            this.clientComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clientComboBox.FormattingEnabled = true;
            this.clientComboBox.Location = new System.Drawing.Point(170, 463);
            this.clientComboBox.Name = "clientComboBox";
            this.clientComboBox.Size = new System.Drawing.Size(200, 21);
            this.clientComboBox.TabIndex = 117;
            this.clientComboBox.ValueMember = "Client_Institution";
            // 
            // clientInstitutionBindingSource
            // 
            this.clientInstitutionBindingSource.DataMember = "ClientInstitution";
            this.clientInstitutionBindingSource.DataSource = this.forAmazonDataSet;
            // 
            // latest_CommentTextBox
            // 
            this.latest_CommentTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource, "Latest_Comment", true));
            this.latest_CommentTextBox.Location = new System.Drawing.Point(170, 490);
            this.latest_CommentTextBox.Name = "latest_CommentTextBox";
            this.latest_CommentTextBox.Size = new System.Drawing.Size(200, 20);
            this.latest_CommentTextBox.TabIndex = 119;
            // 
            // latest_Person_ContactedComboBox
            // 
            this.latest_Person_ContactedComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource, "Latest_Person_Contacted", true));
            this.latest_Person_ContactedComboBox.DataSource = this.contactedPersonBindingSource;
            this.latest_Person_ContactedComboBox.DisplayMember = "Contacted_person";
            this.latest_Person_ContactedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.latest_Person_ContactedComboBox.FormattingEnabled = true;
            this.latest_Person_ContactedComboBox.Location = new System.Drawing.Point(170, 516);
            this.latest_Person_ContactedComboBox.Name = "latest_Person_ContactedComboBox";
            this.latest_Person_ContactedComboBox.Size = new System.Drawing.Size(200, 21);
            this.latest_Person_ContactedComboBox.TabIndex = 121;
            this.latest_Person_ContactedComboBox.ValueMember = "Contacted_person";
            // 
            // contactedPersonBindingSource
            // 
            this.contactedPersonBindingSource.DataMember = "ContactedPerson";
            this.contactedPersonBindingSource.DataSource = this.forAmazonDataSet;
            // 
            // reactionComboBox
            // 
            this.reactionComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource, "Reaction", true));
            this.reactionComboBox.DataSource = this.reactionsBindingSource;
            this.reactionComboBox.DisplayMember = "Reaction_Type";
            this.reactionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.reactionComboBox.FormattingEnabled = true;
            this.reactionComboBox.Location = new System.Drawing.Point(170, 543);
            this.reactionComboBox.Name = "reactionComboBox";
            this.reactionComboBox.Size = new System.Drawing.Size(200, 21);
            this.reactionComboBox.TabIndex = 123;
            this.reactionComboBox.ValueMember = "Reaction_Type";
            // 
            // reactionsBindingSource
            // 
            this.reactionsBindingSource.DataMember = "Reactions";
            this.reactionsBindingSource.DataSource = this.forAmazonDataSet;
            // 
            // contactedViaTextBox
            // 
            this.contactedViaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource, "ContactedVia", true));
            this.contactedViaTextBox.Location = new System.Drawing.Point(170, 570);
            this.contactedViaTextBox.Name = "contactedViaTextBox";
            this.contactedViaTextBox.Size = new System.Drawing.Size(200, 20);
            this.contactedViaTextBox.TabIndex = 125;
            // 
            // closeDateDateTimePicker
            // 
            this.closeDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.debtorsActiveBindingSource, "CloseDate", true));
            this.closeDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.closeDateDateTimePicker.Location = new System.Drawing.Point(279, 601);
            this.closeDateDateTimePicker.Name = "closeDateDateTimePicker";
            this.closeDateDateTimePicker.Size = new System.Drawing.Size(91, 20);
            this.closeDateDateTimePicker.TabIndex = 129;
            this.closeDateDateTimePicker.ValueChanged += new System.EventHandler(this.closeDateDateTimePicker_ValueChanged);
            // 
            // branchIdTextBox
            // 
            this.branchIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource, "BranchId", true));
            this.branchIdTextBox.Location = new System.Drawing.Point(557, 147);
            this.branchIdTextBox.Name = "branchIdTextBox";
            this.branchIdTextBox.Size = new System.Drawing.Size(200, 20);
            this.branchIdTextBox.TabIndex = 131;
            // 
            // disbursmentDateDateTimePicker
            // 
            this.disbursmentDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.debtorsActiveBindingSource, "DisbursmentDate", true));
            this.disbursmentDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.disbursmentDateDateTimePicker.Location = new System.Drawing.Point(279, 631);
            this.disbursmentDateDateTimePicker.Name = "disbursmentDateDateTimePicker";
            this.disbursmentDateDateTimePicker.Size = new System.Drawing.Size(89, 20);
            this.disbursmentDateDateTimePicker.TabIndex = 133;
            this.disbursmentDateDateTimePicker.ValueChanged += new System.EventHandler(this.disbursmentDateDateTimePicker_ValueChanged);
            // 
            // finishedDateDateTimePicker
            // 
            this.finishedDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.debtorsActiveBindingSource, "FinishedDate", true));
            this.finishedDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.finishedDateDateTimePicker.Location = new System.Drawing.Point(279, 657);
            this.finishedDateDateTimePicker.Name = "finishedDateDateTimePicker";
            this.finishedDateDateTimePicker.Size = new System.Drawing.Size(89, 20);
            this.finishedDateDateTimePicker.TabIndex = 135;
            this.finishedDateDateTimePicker.ValueChanged += new System.EventHandler(this.finishedDateDateTimePicker_ValueChanged);
            // 
            // avgMoRepaymentTextBox
            // 
            this.avgMoRepaymentTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource, "AvgMoRepayment", true));
            this.avgMoRepaymentTextBox.Location = new System.Drawing.Point(557, 539);
            this.avgMoRepaymentTextBox.Name = "avgMoRepaymentTextBox";
            this.avgMoRepaymentTextBox.Size = new System.Drawing.Size(200, 20);
            this.avgMoRepaymentTextBox.TabIndex = 141;
            // 
            // pMTpercentageTextBox
            // 
            this.pMTpercentageTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource, "PMTpercentage", true));
            this.pMTpercentageTextBox.Location = new System.Drawing.Point(557, 565);
            this.pMTpercentageTextBox.Name = "pMTpercentageTextBox";
            this.pMTpercentageTextBox.Size = new System.Drawing.Size(200, 20);
            this.pMTpercentageTextBox.TabIndex = 143;
            // 
            // restructuredContractTextBox
            // 
            this.restructuredContractTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource, "RestructuredContract", true));
            this.restructuredContractTextBox.Location = new System.Drawing.Point(557, 591);
            this.restructuredContractTextBox.Name = "restructuredContractTextBox";
            this.restructuredContractTextBox.Size = new System.Drawing.Size(200, 20);
            this.restructuredContractTextBox.TabIndex = 145;
            // 
            // isRestructuredTextBox
            // 
            this.isRestructuredTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource, "IsRestructured", true));
            this.isRestructuredTextBox.Location = new System.Drawing.Point(556, 617);
            this.isRestructuredTextBox.Name = "isRestructuredTextBox";
            this.isRestructuredTextBox.Size = new System.Drawing.Size(200, 20);
            this.isRestructuredTextBox.TabIndex = 147;
            // 
            // mortgageTextBox
            // 
            this.mortgageTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource, "Mortgage", true));
            this.mortgageTextBox.Location = new System.Drawing.Point(557, 43);
            this.mortgageTextBox.Name = "mortgageTextBox";
            this.mortgageTextBox.Size = new System.Drawing.Size(200, 20);
            this.mortgageTextBox.TabIndex = 199;
            // 
            // pledgeTextBox
            // 
            this.pledgeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource, "Pledge", true));
            this.pledgeTextBox.Location = new System.Drawing.Point(557, 69);
            this.pledgeTextBox.Name = "pledgeTextBox";
            this.pledgeTextBox.Size = new System.Drawing.Size(200, 20);
            this.pledgeTextBox.TabIndex = 201;
            // 
            // cashColateralTextBox
            // 
            this.cashColateralTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource, "CashColateral", true));
            this.cashColateralTextBox.Location = new System.Drawing.Point(557, 95);
            this.cashColateralTextBox.Name = "cashColateralTextBox";
            this.cashColateralTextBox.Size = new System.Drawing.Size(200, 20);
            this.cashColateralTextBox.TabIndex = 203;
            // 
            // contractStatusIdTextBox
            // 
            this.contractStatusIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource, "ContractStatusId", true));
            this.contractStatusIdTextBox.Location = new System.Drawing.Point(557, 121);
            this.contractStatusIdTextBox.Name = "contractStatusIdTextBox";
            this.contractStatusIdTextBox.Size = new System.Drawing.Size(200, 20);
            this.contractStatusIdTextBox.TabIndex = 205;
            // 
            // linkIDTextBox
            // 
            this.linkIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource, "LinkID", true));
            this.linkIDTextBox.Location = new System.Drawing.Point(557, 173);
            this.linkIDTextBox.Name = "linkIDTextBox";
            this.linkIDTextBox.Size = new System.Drawing.Size(200, 20);
            this.linkIDTextBox.TabIndex = 209;
            // 
            // classificationTextBox
            // 
            this.classificationTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource, "Classification", true));
            this.classificationTextBox.Location = new System.Drawing.Point(557, 199);
            this.classificationTextBox.Name = "classificationTextBox";
            this.classificationTextBox.Size = new System.Drawing.Size(200, 20);
            this.classificationTextBox.TabIndex = 211;
            // 
            // payAccNoTextBox
            // 
            this.payAccNoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource, "PayAccNo", true));
            this.payAccNoTextBox.Location = new System.Drawing.Point(557, 225);
            this.payAccNoTextBox.Name = "payAccNoTextBox";
            this.payAccNoTextBox.Size = new System.Drawing.Size(200, 20);
            this.payAccNoTextBox.TabIndex = 213;
            // 
            // assignmentDebtTextBox
            // 
            this.assignmentDebtTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource3, "AssignmentDebt", true));
            this.assignmentDebtTextBox.Location = new System.Drawing.Point(557, 251);
            this.assignmentDebtTextBox.Name = "assignmentDebtTextBox";
            this.assignmentDebtTextBox.Size = new System.Drawing.Size(200, 20);
            this.assignmentDebtTextBox.TabIndex = 215;
            // 
            // debtorsActiveBindingSource3
            // 
            this.debtorsActiveBindingSource3.DataMember = "DebtorsActive";
            this.debtorsActiveBindingSource3.DataSource = this.forAmazonDataSet;
            // 
            // debt_Id1TextBox
            // 
            this.debt_Id1TextBox.Location = new System.Drawing.Point(169, 65);
            this.debt_Id1TextBox.Name = "debt_Id1TextBox";
            this.debt_Id1TextBox.ReadOnly = true;
            this.debt_Id1TextBox.Size = new System.Drawing.Size(200, 20);
            this.debt_Id1TextBox.TabIndex = 217;
            // 
            // total_Outstanding1TextBox
            // 
            this.total_Outstanding1TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource2, "Total_Outstanding", true));
            this.total_Outstanding1TextBox.Location = new System.Drawing.Point(169, 332);
            this.total_Outstanding1TextBox.Name = "total_Outstanding1TextBox";
            this.total_Outstanding1TextBox.Size = new System.Drawing.Size(200, 20);
            this.total_Outstanding1TextBox.TabIndex = 219;
            // 
            // debtorsActiveBindingSource2
            // 
            this.debtorsActiveBindingSource2.DataMember = "DebtorsActive";
            this.debtorsActiveBindingSource2.DataSource = this.forAmazonDataSet;
            // 
            // debtorsActiveBindingSource1
            // 
            this.debtorsActiveBindingSource1.DataMember = "DebtorsActive";
            this.debtorsActiveBindingSource1.DataSource = this.forAmazonDataSet;
            // 
            // disbursmentAmountTextBox
            // 
            this.disbursmentAmountTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource5, "DisbursmentAmount", true));
            this.disbursmentAmountTextBox.Location = new System.Drawing.Point(557, 303);
            this.disbursmentAmountTextBox.Name = "disbursmentAmountTextBox";
            this.disbursmentAmountTextBox.Size = new System.Drawing.Size(200, 20);
            this.disbursmentAmountTextBox.TabIndex = 231;
            // 
            // debtorsActiveBindingSource5
            // 
            this.debtorsActiveBindingSource5.DataMember = "DebtorsActive";
            this.debtorsActiveBindingSource5.DataSource = this.forAmazonDataSet;
            // 
            // inALL_BaseTextBox
            // 
            this.inALL_BaseTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.forAmazonDataSet, "DebtorsActive.InALL_Base", true));
            this.inALL_BaseTextBox.Location = new System.Drawing.Point(557, 329);
            this.inALL_BaseTextBox.Name = "inALL_BaseTextBox";
            this.inALL_BaseTextBox.Size = new System.Drawing.Size(200, 20);
            this.inALL_BaseTextBox.TabIndex = 233;
            // 
            // amountInDelayTextBox
            // 
            this.amountInDelayTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource6, "AmountInDelay", true));
            this.amountInDelayTextBox.Location = new System.Drawing.Point(557, 355);
            this.amountInDelayTextBox.Name = "amountInDelayTextBox";
            this.amountInDelayTextBox.Size = new System.Drawing.Size(200, 20);
            this.amountInDelayTextBox.TabIndex = 235;
            // 
            // debtorsActiveBindingSource6
            // 
            this.debtorsActiveBindingSource6.DataMember = "DebtorsActive";
            this.debtorsActiveBindingSource6.DataSource = this.forAmazonDataSet;
            // 
            // principalDelayTextBox
            // 
            this.principalDelayTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource7, "PrincipalDelay", true));
            this.principalDelayTextBox.Location = new System.Drawing.Point(557, 381);
            this.principalDelayTextBox.Name = "principalDelayTextBox";
            this.principalDelayTextBox.Size = new System.Drawing.Size(200, 20);
            this.principalDelayTextBox.TabIndex = 237;
            // 
            // debtorsActiveBindingSource7
            // 
            this.debtorsActiveBindingSource7.DataMember = "DebtorsActive";
            this.debtorsActiveBindingSource7.DataSource = this.forAmazonDataSet;
            // 
            // interestDelayTextBox
            // 
            this.interestDelayTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource8, "InterestDelay", true));
            this.interestDelayTextBox.Location = new System.Drawing.Point(557, 407);
            this.interestDelayTextBox.Name = "interestDelayTextBox";
            this.interestDelayTextBox.Size = new System.Drawing.Size(200, 20);
            this.interestDelayTextBox.TabIndex = 239;
            // 
            // debtorsActiveBindingSource8
            // 
            this.debtorsActiveBindingSource8.DataMember = "DebtorsActive";
            this.debtorsActiveBindingSource8.DataSource = this.forAmazonDataSet;
            // 
            // upComingInterestTextBox
            // 
            this.upComingInterestTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource9, "UpComingInterest", true));
            this.upComingInterestTextBox.Location = new System.Drawing.Point(557, 433);
            this.upComingInterestTextBox.Name = "upComingInterestTextBox";
            this.upComingInterestTextBox.Size = new System.Drawing.Size(200, 20);
            this.upComingInterestTextBox.TabIndex = 241;
            // 
            // debtorsActiveBindingSource9
            // 
            this.debtorsActiveBindingSource9.DataMember = "DebtorsActive";
            this.debtorsActiveBindingSource9.DataSource = this.forAmazonDataSet;
            // 
            // clientSegmentTextBox
            // 
            this.clientSegmentTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource, "ClientSegment", true));
            this.clientSegmentTextBox.Location = new System.Drawing.Point(557, 459);
            this.clientSegmentTextBox.Name = "clientSegmentTextBox";
            this.clientSegmentTextBox.Size = new System.Drawing.Size(200, 20);
            this.clientSegmentTextBox.TabIndex = 243;
            // 
            // productIDTextBox
            // 
            this.productIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource, "ProductID", true));
            this.productIDTextBox.Location = new System.Drawing.Point(557, 485);
            this.productIDTextBox.Name = "productIDTextBox";
            this.productIDTextBox.Size = new System.Drawing.Size(200, 20);
            this.productIDTextBox.TabIndex = 245;
            // 
            // daysInDelayTextBox
            // 
            this.daysInDelayTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource, "DaysInDelay", true));
            this.daysInDelayTextBox.Location = new System.Drawing.Point(557, 511);
            this.daysInDelayTextBox.Name = "daysInDelayTextBox";
            this.daysInDelayTextBox.Size = new System.Drawing.Size(200, 20);
            this.daysInDelayTextBox.TabIndex = 247;
            // 
            // contactedPersonTableAdapter
            // 
            this.contactedPersonTableAdapter.ClearBeforeFill = true;
            // 
            // buttonDeleteD
            // 
            this.buttonDeleteD.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonDeleteD.FlatAppearance.BorderSize = 0;
            this.buttonDeleteD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteD.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteD.ForeColor = System.Drawing.Color.Red;
            this.buttonDeleteD.Location = new System.Drawing.Point(422, 677);
            this.buttonDeleteD.Name = "buttonDeleteD";
            this.buttonDeleteD.Size = new System.Drawing.Size(111, 27);
            this.buttonDeleteD.TabIndex = 248;
            this.buttonDeleteD.Text = "Delete";
            this.buttonDeleteD.UseVisualStyleBackColor = false;
            this.buttonDeleteD.Click += new System.EventHandler(this.buttonDeleteD_Click);
            // 
            // pTP_AmountTextBox
            // 
            this.pTP_AmountTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource4, "PTP_Amount", true));
            this.pTP_AmountTextBox.Location = new System.Drawing.Point(556, 276);
            this.pTP_AmountTextBox.Name = "pTP_AmountTextBox";
            this.pTP_AmountTextBox.Size = new System.Drawing.Size(200, 20);
            this.pTP_AmountTextBox.TabIndex = 250;
            // 
            // debtorsActiveBindingSource4
            // 
            this.debtorsActiveBindingSource4.DataMember = "DebtorsActive";
            this.debtorsActiveBindingSource4.DataSource = this.forAmazonDataSet;
            // 
            // comboBoxDCollector
            // 
            this.comboBoxDCollector.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource, "Debt_Collector", true));
            this.comboBoxDCollector.DataSource = this.usernamesBindingSource1;
            this.comboBoxDCollector.DisplayMember = "Collector";
            this.comboBoxDCollector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDCollector.FormattingEnabled = true;
            this.comboBoxDCollector.Location = new System.Drawing.Point(168, 305);
            this.comboBoxDCollector.Name = "comboBoxDCollector";
            this.comboBoxDCollector.Size = new System.Drawing.Size(200, 21);
            this.comboBoxDCollector.TabIndex = 251;
            this.comboBoxDCollector.ValueMember = "Collector";
            // 
            // usernamesBindingSource1
            // 
            this.usernamesBindingSource1.DataMember = "Usernames";
            this.usernamesBindingSource1.DataSource = this.forAmazonDataSet;
            // 
            // usernamesBindingSource2
            // 
            this.usernamesBindingSource2.DataMember = "Usernames";
            this.usernamesBindingSource2.DataSource = this.forAmazonDataSet;
            // 
            // clientInstitutionTableAdapter
            // 
            this.clientInstitutionTableAdapter.ClearBeforeFill = true;
            // 
            // reactionsTableAdapter
            // 
            this.reactionsTableAdapter.ClearBeforeFill = true;
            // 
            // textBoxClDate
            // 
            this.textBoxClDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource, "CloseDate", true));
            this.textBoxClDate.Location = new System.Drawing.Point(169, 601);
            this.textBoxClDate.Name = "textBoxClDate";
            this.textBoxClDate.Size = new System.Drawing.Size(93, 20);
            this.textBoxClDate.TabIndex = 252;
            // 
            // textBoxDbDate
            // 
            this.textBoxDbDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource, "DisbursmentDate", true));
            this.textBoxDbDate.Location = new System.Drawing.Point(169, 631);
            this.textBoxDbDate.Name = "textBoxDbDate";
            this.textBoxDbDate.Size = new System.Drawing.Size(93, 20);
            this.textBoxDbDate.TabIndex = 253;
            // 
            // textBoxFinDate
            // 
            this.textBoxFinDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorsActiveBindingSource, "FinishedDate", true));
            this.textBoxFinDate.Location = new System.Drawing.Point(169, 658);
            this.textBoxFinDate.Name = "textBoxFinDate";
            this.textBoxFinDate.Size = new System.Drawing.Size(93, 20);
            this.textBoxFinDate.TabIndex = 254;
            // 
            // debtTypeBindingSource2
            // 
            this.debtTypeBindingSource2.DataMember = "DebtType";
            this.debtTypeBindingSource2.DataSource = this.forAmazonDataSet;
            // 
            // portofolioStatusBindingSource3
            // 
            this.portofolioStatusBindingSource3.DataMember = "PortofolioStatus";
            this.portofolioStatusBindingSource3.DataSource = this.forAmazonDataSet;
            // 
            // EditDebtor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(786, 741);
            this.Controls.Add(this.textBoxFinDate);
            this.Controls.Add(this.textBoxDbDate);
            this.Controls.Add(this.textBoxClDate);
            this.Controls.Add(this.comboBoxDCollector);
            this.Controls.Add(pTP_AmountLabel);
            this.Controls.Add(this.pTP_AmountTextBox);
            this.Controls.Add(this.buttonDeleteD);
            this.Controls.Add(disbursmentAmountLabel);
            this.Controls.Add(this.disbursmentAmountTextBox);
            this.Controls.Add(inALL_BaseLabel);
            this.Controls.Add(this.inALL_BaseTextBox);
            this.Controls.Add(amountInDelayLabel);
            this.Controls.Add(this.amountInDelayTextBox);
            this.Controls.Add(principalDelayLabel);
            this.Controls.Add(this.principalDelayTextBox);
            this.Controls.Add(interestDelayLabel);
            this.Controls.Add(this.interestDelayTextBox);
            this.Controls.Add(upComingInterestLabel);
            this.Controls.Add(this.upComingInterestTextBox);
            this.Controls.Add(clientSegmentLabel);
            this.Controls.Add(this.clientSegmentTextBox);
            this.Controls.Add(productIDLabel);
            this.Controls.Add(this.productIDTextBox);
            this.Controls.Add(daysInDelayLabel);
            this.Controls.Add(this.daysInDelayTextBox);
            this.Controls.Add(mortgageLabel);
            this.Controls.Add(this.mortgageTextBox);
            this.Controls.Add(pledgeLabel);
            this.Controls.Add(this.pledgeTextBox);
            this.Controls.Add(cashColateralLabel);
            this.Controls.Add(this.cashColateralTextBox);
            this.Controls.Add(contractStatusIdLabel);
            this.Controls.Add(this.contractStatusIdTextBox);
            this.Controls.Add(linkIDLabel);
            this.Controls.Add(this.linkIDTextBox);
            this.Controls.Add(classificationLabel);
            this.Controls.Add(this.classificationTextBox);
            this.Controls.Add(payAccNoLabel);
            this.Controls.Add(this.payAccNoTextBox);
            this.Controls.Add(assignmentDebtLabel);
            this.Controls.Add(this.assignmentDebtTextBox);
            this.Controls.Add(debt_Id1Label);
            this.Controls.Add(this.debt_Id1TextBox);
            this.Controls.Add(this.total_Outstanding1TextBox);
            this.Controls.Add(debt_Serial_NumberLabel);
            this.Controls.Add(this.debt_Serial_NumberLabel1);
            this.Controls.Add(debt_TypeLabel);
            this.Controls.Add(this.debt_TypeComboBox);
            this.Controls.Add(debtor_Full_NameLabel);
            this.Controls.Add(this.debtor_Full_NameTextBox);
            this.Controls.Add(portfolio_StatusLabel);
            this.Controls.Add(this.portfolio_StatusComboBox);
            this.Controls.Add(outstanding_PrincipalLabel);
            this.Controls.Add(this.outstanding_PrincipalTextBox);
            this.Controls.Add(outstanding_InterestLabel);
            this.Controls.Add(this.outstanding_InterestTextBox);
            this.Controls.Add(outstanding_PenaltyLabel);
            this.Controls.Add(this.outstanding_PenaltyTextBox);
            this.Controls.Add(currencyLabel);
            this.Controls.Add(this.currencyComboBox);
            this.Controls.Add(portfolioLabel);
            this.Controls.Add(this.portfolioTextBox);
            this.Controls.Add(debt_CollectorLabel);
            this.Controls.Add(total_OutstandingLabel);
            this.Controls.Add(assigment_DateLabel);
            this.Controls.Add(this.assigment_DateDateTimePicker);
            this.Controls.Add(client_BranchLabel);
            this.Controls.Add(this.client_BranchTextBox);
            this.Controls.Add(last_Act_typeLabel);
            this.Controls.Add(this.last_Act_typeTextBox);
            this.Controls.Add(next_Action_DateLabel);
            this.Controls.Add(this.next_Action_DateDateTimePicker);
            this.Controls.Add(clientLabel);
            this.Controls.Add(this.clientComboBox);
            this.Controls.Add(latest_CommentLabel);
            this.Controls.Add(this.latest_CommentTextBox);
            this.Controls.Add(latest_Person_ContactedLabel);
            this.Controls.Add(this.latest_Person_ContactedComboBox);
            this.Controls.Add(reactionLabel);
            this.Controls.Add(this.reactionComboBox);
            this.Controls.Add(contactedViaLabel);
            this.Controls.Add(this.contactedViaTextBox);
            this.Controls.Add(closeDateLabel);
            this.Controls.Add(this.closeDateDateTimePicker);
            this.Controls.Add(branchIdLabel);
            this.Controls.Add(this.branchIdTextBox);
            this.Controls.Add(disbursmentDateLabel);
            this.Controls.Add(this.disbursmentDateDateTimePicker);
            this.Controls.Add(finishedDateLabel);
            this.Controls.Add(this.finishedDateDateTimePicker);
            this.Controls.Add(avgMoRepaymentLabel);
            this.Controls.Add(this.avgMoRepaymentTextBox);
            this.Controls.Add(pMTpercentageLabel);
            this.Controls.Add(this.pMTpercentageTextBox);
            this.Controls.Add(restructuredContractLabel);
            this.Controls.Add(this.restructuredContractTextBox);
            this.Controls.Add(isRestructuredLabel);
            this.Controls.Add(this.isRestructuredTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxPass);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(880, 860);
            this.Name = "EditDebtor";
            this.Text = "Edit Debtor";
            this.Load += new System.EventHandler(this.EditDebtor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.usernamesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.forAmazonDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portofolioStatusBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.debtTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portofolioStatusBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portofolioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currencyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.debtorsActiveBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.debtTypeBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portofolioStatusBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientInstitutionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactedPersonBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reactionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.debtorsActiveBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.debtorsActiveBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.debtorsActiveBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.debtorsActiveBindingSource5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.debtorsActiveBindingSource6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.debtorsActiveBindingSource7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.debtorsActiveBindingSource8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.debtorsActiveBindingSource9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.debtorsActiveBindingSource4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usernamesBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usernamesBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.debtTypeBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portofolioStatusBindingSource3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.Label label8;
        private ForAmazonDataSet forAmazonDataSet;
        private System.Windows.Forms.BindingSource portofolioStatusBindingSource;
        private ForAmazonDataSetTableAdapters.PortofolioStatusTableAdapter portofolioStatusTableAdapter;
        private System.Windows.Forms.BindingSource usernamesBindingSource;
        private ForAmazonDataSetTableAdapters.UsernamesTableAdapter usernamesTableAdapter;
        private System.Windows.Forms.BindingSource debtTypeBindingSource;
        private ForAmazonDataSetTableAdapters.DebtTypeTableAdapter debtTypeTableAdapter;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.BindingSource currencyBindingSource;
        private ForAmazonDataSetTableAdapters.CurrencyTableAdapter currencyTableAdapter;
        private System.Windows.Forms.BindingSource portofolioBindingSource;
        private ForAmazonDataSetTableAdapters.PortofolioTableAdapter portofolioTableAdapter;
        private System.Windows.Forms.BindingSource portofolioStatusBindingSource1;
        private System.Windows.Forms.BindingSource debtorsActiveBindingSource;
        private ForAmazonDataSetTableAdapters.DebtorsActiveTableAdapter debtorsActiveTableAdapter;
        private ForAmazonDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Label debt_Serial_NumberLabel1;
        private System.Windows.Forms.ComboBox debt_TypeComboBox;
        private System.Windows.Forms.TextBox debtor_Full_NameTextBox;
        private System.Windows.Forms.ComboBox portfolio_StatusComboBox;
        private System.Windows.Forms.TextBox outstanding_PrincipalTextBox;
        private System.Windows.Forms.TextBox outstanding_InterestTextBox;
        private System.Windows.Forms.TextBox outstanding_PenaltyTextBox;
        private System.Windows.Forms.ComboBox currencyComboBox;
        private System.Windows.Forms.TextBox portfolioTextBox;
        private System.Windows.Forms.DateTimePicker assigment_DateDateTimePicker;
        private System.Windows.Forms.TextBox client_BranchTextBox;
        private System.Windows.Forms.TextBox last_Act_typeTextBox;
        private System.Windows.Forms.DateTimePicker next_Action_DateDateTimePicker;
        private System.Windows.Forms.ComboBox clientComboBox;
        private System.Windows.Forms.TextBox latest_CommentTextBox;
        private System.Windows.Forms.ComboBox latest_Person_ContactedComboBox;
        private System.Windows.Forms.ComboBox reactionComboBox;
        private System.Windows.Forms.TextBox contactedViaTextBox;
        private System.Windows.Forms.DateTimePicker closeDateDateTimePicker;
        private System.Windows.Forms.TextBox branchIdTextBox;
        private System.Windows.Forms.DateTimePicker disbursmentDateDateTimePicker;
        private System.Windows.Forms.DateTimePicker finishedDateDateTimePicker;
        private System.Windows.Forms.TextBox avgMoRepaymentTextBox;
        private System.Windows.Forms.TextBox pMTpercentageTextBox;
        private System.Windows.Forms.TextBox restructuredContractTextBox;
        private System.Windows.Forms.TextBox isRestructuredTextBox;
        private System.Windows.Forms.TextBox mortgageTextBox;
        private System.Windows.Forms.TextBox pledgeTextBox;
        private System.Windows.Forms.TextBox cashColateralTextBox;
        private System.Windows.Forms.TextBox contractStatusIdTextBox;
        private System.Windows.Forms.TextBox linkIDTextBox;
        private System.Windows.Forms.TextBox classificationTextBox;
        private System.Windows.Forms.TextBox payAccNoTextBox;
        private System.Windows.Forms.TextBox assignmentDebtTextBox;
        private System.Windows.Forms.TextBox debt_Id1TextBox;
        private System.Windows.Forms.TextBox total_Outstanding1TextBox;
        private System.Windows.Forms.TextBox disbursmentAmountTextBox;
        private System.Windows.Forms.TextBox inALL_BaseTextBox;
        private System.Windows.Forms.TextBox amountInDelayTextBox;
        private System.Windows.Forms.TextBox principalDelayTextBox;
        private System.Windows.Forms.TextBox interestDelayTextBox;
        private System.Windows.Forms.TextBox upComingInterestTextBox;
        private System.Windows.Forms.TextBox clientSegmentTextBox;
        private System.Windows.Forms.TextBox productIDTextBox;
        private System.Windows.Forms.TextBox daysInDelayTextBox;
        private System.Windows.Forms.BindingSource debtTypeBindingSource1;
        private System.Windows.Forms.BindingSource contactedPersonBindingSource;
        private ForAmazonDataSetTableAdapters.ContactedPersonTableAdapter contactedPersonTableAdapter;
        private System.Windows.Forms.Button buttonDeleteD;
        private System.Windows.Forms.TextBox pTP_AmountTextBox;
        private System.Windows.Forms.BindingSource debtorsActiveBindingSource1;
        private System.Windows.Forms.BindingSource debtorsActiveBindingSource2;
        private System.Windows.Forms.ComboBox comboBoxDCollector;
        private System.Windows.Forms.BindingSource usernamesBindingSource2;
        private System.Windows.Forms.BindingSource usernamesBindingSource1;
        private System.Windows.Forms.BindingSource clientInstitutionBindingSource;
        private ForAmazonDataSetTableAdapters.ClientInstitutionTableAdapter clientInstitutionTableAdapter;
        private System.Windows.Forms.BindingSource reactionsBindingSource;
        private ForAmazonDataSetTableAdapters.ReactionsTableAdapter reactionsTableAdapter;
        private System.Windows.Forms.TextBox textBoxClDate;
        private System.Windows.Forms.TextBox textBoxDbDate;
        private System.Windows.Forms.TextBox textBoxFinDate;
        private System.Windows.Forms.BindingSource portofolioStatusBindingSource2;
        private System.Windows.Forms.BindingSource debtorsActiveBindingSource3;
        private System.Windows.Forms.BindingSource debtorsActiveBindingSource5;
        private System.Windows.Forms.BindingSource debtorsActiveBindingSource6;
        private System.Windows.Forms.BindingSource debtorsActiveBindingSource7;
        private System.Windows.Forms.BindingSource debtorsActiveBindingSource8;
        private System.Windows.Forms.BindingSource debtorsActiveBindingSource9;
        private System.Windows.Forms.BindingSource debtorsActiveBindingSource4;
        private System.Windows.Forms.BindingSource debtTypeBindingSource2;
        private System.Windows.Forms.BindingSource portofolioStatusBindingSource3;
    }
}